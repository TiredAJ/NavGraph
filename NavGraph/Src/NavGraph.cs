// Ignore Spelling: Nav UID AUID BUID Deserialise

using NavGraphTools.Utilities;
using System.Text.Json;
using System.Text.Json.Serialization;
using TupleAsJsonArray;

namespace NavGraphTools;

public class NavGraph : Graph<NavNode>
{
    #region MemberVariables
    //reserves 50 UIDs for flags and such:
    //UID 0 = no node
    public const int MINIMUM_UID = 25;
    //if uid is negative & < -25, it's a one-way connection
    //for example, if A -> B is one way, A would store B's UID, but B would store the negative of A's UID

    ///For generating new UIDs
    [JsonInclude]
    internal int BaseUID = MINIMUM_UID;

    [JsonInclude]
    public Dictionary<string, (int Max, int Min)> Blocks = new Dictionary<string, (int Max, int Min)>();
    //                              ^No floors
    //                  ^Block name

    [JsonIgnore]
    public Dictionary<string, int> Tags = new();
    //                         ^ how many nodes use this tag
    //                  ^Tag

    //The next assignable UID
    [JsonInclude]
    private int _AvailableUID;

    [JsonIgnore]
    internal int AvailableUID
    {
        get
        { return _AvailableUID++; }

        set
        { _AvailableUID = value; }
    }

    [JsonIgnore]
    private JsonSerializerOptions JSO;


    [JsonInclude]
    private int _NextENGroupID = 1;

    [JsonIgnore]
    private int NextENGroupID
    { get => _NextENGroupID++; }

    [JsonIgnore]
    public int NodeCount
    { get => Nodes.Count; }
    #endregion

    /// <summary>
    /// Default Constructor
    /// </summary>
    /// <param name="GenerateNewGraph"><see langword="true"/> if you're creating a new graph, <see langword="false"/> if you're going to read in data</param>
    public NavGraph(bool GenerateNewGraph) : base(GenerateNewGraph)
    {
        if (GenerateNewGraph)
        {
            Random RND = new Random(((int)DateTime.Now.Ticks));

            //generates a base UID from MINIMUM_UID to 6553
            BaseUID = RND.Next(MINIMUM_UID, 6553);

            _AvailableUID = BaseUID++;
        }
    }

    /// <summary>
    /// For deserialisation
    /// </summary>
    public NavGraph()
    {
        BaseUID = MINIMUM_UID;
        Blocks = new Dictionary<string, (int Max, int Min)>();
        _AvailableUID = BaseUID + 1;
    }

    #region Adding Nodes
    /// <summary>
    /// Adds a node to the dictionary with a randomly assigned UID
    /// </summary>
    /// <param name="_NewNode">The node to be added</param>
    /// <returns>UID if succesful, 0 if it fails</returns>
    public int AddNode(NavNode _NewNode)
    {
        //auto increments
        int TempUID = AvailableUID;

        //increments on loop until it finds a new key
        while (Nodes.ContainsKey(TempUID))
        { TempUID = AvailableUID; }

        //assigns the node it's UID
        _NewNode.UID = TempUID;

        //adds the node to the Dictionary
        Nodes.Add(TempUID, _NewNode);

        if (_NewNode is RoomNode RN && RN.Tags is not null && RN.Tags.Count > 0)
        {
            foreach (var T in RN.Tags)
            { AddOrIncrementTag(T); }
        }

        //returns the assigned UID
        return TempUID;

        //Note: it may run for a while possibly if it struggles to find a new key
    }
    #endregion

    #region Set
    /// <summary>
    /// Sets the node at the specified UID
    /// </summary>
    /// <param name="_UID">UID of node to overwrite</param>
    /// <param name="_NewNode">New node to overwrite old data</param>
    /// <returns><see langword="true"/> if successful, <see langword="false"/> otherwise</returns>
    public bool SetNode(int _UID, NavNode _NewNode)
    {
        _UID = Math.Abs(_UID);

        if (Nodes.ContainsKey(_UID))
        {
            Nodes[_UID] = _NewNode;
            return true;
        }
        else
        { return false; }
    }
    #endregion

    #region Get
    /// <summary>
    /// Gets all the nodes of a particular block.
    /// </summary>
    /// <param name="_Block">Name of blocks to get nodes from</param>
    /// <returns>A dictionary of UIDs and NavNodes</returns>
    public Dictionary<int, NavNode> GetNodes(string _Block)
        => GetAllNodes()
            .Where(X => X.Value.BlockName == _Block)
            .ToDictionary(X => X.Key,
                        Y => Y.Value);

    /// <summary>
    /// Gets all the nodes of a particular floor in a specific block.
    /// </summary>
    /// <param name="_Block">Name of blocks to get nodes from</param>
    /// <param name="_Floor">Floor to get nodes from</param>
    /// <returns>A dictionary of UIDs and NavNodes</returns>
    public Dictionary<int, NavNode> GetNodes(string _Block, int _Floor)
        => GetAllNodes()
            .Where(X =>
                X.Value.BlockName == _Block &&
                X.Value.Floor == _Floor)
            .ToDictionary(X => X.Key,
                        Y => Y.Value);
    /// <summary>
    /// Gets the number of nodes on a particular floor, in a particular block
    /// </summary>
    /// <param name="_Block">Name of blocks to get nodes from</param>
    /// <param name="_Floor">Floor to get nodes from</param>
    /// <returns>A dictionary of UIDs and NavNodes</returns>
    public int GetFloorNodeCount(string _Block, int _Floor)
        => GetNodes(_Block, _Floor).Count();

    /// <summary>
    /// Gets the nodes connected to a specific node
    /// </summary>
    /// <param name="_UID">UID of node to get connected nodes from</param>
    /// <returns>A dictionary of NodeDirections and NavNodes, null if invalid _UID</returns>
    public Dictionary<NodeDirection, NavNode>? GetConnectedNodes(int _UID)
    {
        if (DoesNodeExist(_UID))
        {
            var Temp = Nodes[_UID].GetConnectedNodes();

            Dictionary<NodeDirection, NavNode> ConnNodes = new();

            foreach (var N in Temp)
            { ConnNodes.Add(N.Key, Nodes[N.Value]); }

            return ConnNodes;
        }
        else
        { return null; }
    }

    /// <summary>
    /// Gets the nodes connected to a specific node of a specific type.
    /// </summary>
    /// <param name="_UID">UID of node to get connected nodes from</param>
    /// <typeparam name="T">Type of nodes to retrieve from _UID's connections</typeparam>
    /// <returns>A dictionary of NodeDirections and NavNodes, null if invalid _UID</returns>
    public Dictionary<NodeDirection, NavNode>? GetConnectedNodes<T>(int _UID) where T : NavNode, ISpecialNode
    {
        if (DoesNodeExist(_UID))
        {
            var Temp = Nodes[_UID].GetConnectedNodes();

            Dictionary<NodeDirection, NavNode> ConnNodes = new();

            foreach (var N in Temp)
            {
                if (Nodes[N.Value] is T)
                { ConnNodes.Add(N.Key, Nodes[N.Value]); }
            }

            return ConnNodes;
        }
        else
        { return null; }
    }

    /// <summary>
    /// Gets the nodes connected to a specific node of a specific type that inherits ISpecialNode.
    /// </summary>
    /// <param name="_UID">UID of node to get connected nodes from</param>
    /// <typeparam name="T">Type of nodes to retrieve from _UID's connections</typeparam>
    /// <returns>A dictionary of NodeDirections and NavNodes, null if invalid _UID</returns>
    public Dictionary<NodeDirection, NavNode>? GetConnectedSpecialNodes<T>(int _UID) where T : ISpecialNode
    {
        if (DoesNodeExist(_UID))
        {
            var Temp = Nodes[_UID].GetConnectedNodes();

            Dictionary<NodeDirection, NavNode> ConnNodes = new();

            foreach (var N in Temp)
            {
                if (Nodes[N.Value] is T)
                { ConnNodes.Add(N.Key, Nodes[N.Value]); }
            }

            return ConnNodes;
        }
        else
        { return null; }
    }

    /// <summary>
    /// Gets the nodes connected to a specific node of a specific type that inherits ISpecialFlow.
    /// </summary>
    /// <param name="_UID">UID of node to get connected nodes from</param>
    /// <typeparam name="T">Type of nodes to retrieve from _UID's connections</typeparam>
    /// <returns>A dictionary of NodeDirections and NavNodes, null if invalid _UID</returns>
    public Dictionary<NodeDirection, NavNode>? GetConnectedFlowNodes<T>(int _UID) where T : ISpecialFlow
    {
        if (DoesNodeExist(_UID))
        {
            var Temp = Nodes[_UID].GetConnectedNodes();

            Dictionary<NodeDirection, NavNode> ConnNodes = new();

            foreach (var N in Temp)
            {
                if (Nodes[N.Value] is T)
                { ConnNodes.Add(N.Key, Nodes[N.Value]); }
            }

            return ConnNodes;
        }
        else
        { return null; }
    }

    #endregion

    #region Connecting Nodes
    /// <summary>
    /// Connects two nodes. Parameters are from the perspective of Node A
    /// </summary>
    /// <param name="_AUID">The UID of Node A</param>
    /// <param name="_BUID">The UID of Node B</param>
    /// <param name="_Dir">Which direction A is connected to B</param>
    /// <param name="_IsOneWay">Whether the connection only goes from A to B</param>
    public void ConnectNodes(int _AUID, int _BUID, NodeDirection _Dir, bool _IsOneWay)
    {
        _AUID = Math.Abs(_AUID);
        _BUID = Math.Abs(_BUID);

        //checks if both nodes exists
        if ((!DoesNodeExist(_AUID) && !DoesNodeExist(_BUID)))
        { throw new Exception("One or both nodes don't exist!"); }
        else if (
            (Nodes[_AUID] is ElevationNode || Nodes[_BUID] is ElevationNode) ||
            (Nodes[_AUID] is GatewayNode || Nodes[_BUID] is GatewayNode))
        { throw new Exception("Please do not connect Elevation or Gateway nodes with this function"); }
        else if (_Dir is (NodeDirection.Up or NodeDirection.Down))
        { throw new Exception("_ND is not valid for this node type"); }

        //connects node B to node A
        Nodes[_AUID].ConnectNode(_BUID, _Dir);

        if (_IsOneWay)
        { Nodes[_BUID].ConnectNode(_AUID * -1, (NodeDirection)((int)_Dir * -1)); }
        else
        { Nodes[_BUID].ConnectNode(_AUID, (NodeDirection)((int)_Dir * -1)); }
    }

    /// <summary>
    /// Connects two elevation nodes either above or below
    /// </summary>
    /// <param name="_AUID">The UID of the Elevation Node A</param>
    /// <param name="_BUID">The UID of the Elevation Node B</param>
    /// <param name="_Dir">Which direction A is connected to B</param>
    public void ConnectElevationNodes(int _AUID, int _BUID, NodeDirection _Dir)
    {
        _AUID = Math.Abs(_AUID);
        _BUID = Math.Abs(_BUID);

        NavNode? TempA;
        NavNode? TempB;

        //checks that both nodes exist in the dictionary and grabs the object
        if (!Nodes.TryGetValue(_AUID, out TempA) || !Nodes.TryGetValue(_BUID, out TempB))
        { throw new Exception("Node does not exist!"); }
        else if (TempA is ElevationNode TA && TempB is ElevationNode TB)
        {
            //could expand this to check that on down conn TB's floor is less than Ta's,
            //but eh
            if ((_Dir is (NodeDirection.Up or NodeDirection.Down)) && TA.Floor == TB.Floor)
            { throw new Exception("For up/down, ENs must be on different floors!"); }

            TA.ConnectNode(_BUID, _Dir);
            TB.ConnectNode(_AUID, (NodeDirection)((int)_Dir * -1));
        }
        else
        { throw new Exception("One or both nodes aren't elevation nodes!"); }
    }

    /// <summary>
    /// Connects an elevation node to a non-elevation node. Only one node must be an 
    /// Elevation node, the other can be any.
    /// </summary>
    /// <param name="_AUID">The UID of Node A</param>
    /// <param name="_BUID">The UID of Node B</param>
    /// <param name="_Dir">Which direction A is connected to B</param>
    /// <param name="_IsOneWay">Whether the connection only goes from A to B</param>
    public void ConnectElevationNodes(int _AUID, int _BUID, NodeDirection _Dir, bool _IsOneWay)
    {
        _AUID = Math.Abs(_AUID);
        _BUID = Math.Abs(_BUID);

        NavNode? A, B;

        //checks that both nodes exist in the dictionary and grabs the object
        if (
                !Nodes.TryGetValue(_AUID, out A) ||
                !Nodes.TryGetValue(_BUID, out B) ||
                Math.Abs((int)_Dir) > 2
            )
        { throw new Exception("Node(s) does not exist!"); }

        if ((A is ElevationNode && B is not ElevationNode)
            || (A is not ElevationNode && B is ElevationNode))
        {
            A.ConnectNode(_BUID, _Dir);
            B.ConnectNode(_AUID, (NodeDirection)((int)_Dir * -1));
        }
        else
        { throw new Exception("One or both nodes aren't elevation nodes!"); }
    }

    /// <summary>
    /// Connects two gateway nodes together
    /// </summary>
    /// <param name="_AUID">UID of first node</param>
    /// <param name="_BUID">UID of second node</param>
    public void ConnectGatewayNodes(int _AUID, int _BUID)
    {
        _AUID = Math.Abs(_AUID);
        _BUID = Math.Abs(_BUID);

        NavNode? A, B;

        if (!Nodes.TryGetValue(_AUID, out A) || !Nodes.TryGetValue(_BUID, out B))
        { throw new Exception("Node(s) does not exist!"); }

        if (A is GatewayNode TA && B is GatewayNode TB)
        {
            TA.ConnectNode(_BUID, TB.BlockName);
            TB.ConnectNode(_AUID, TA.BlockName);
        }
        else
        { throw new Exception("One or both nodes aren't Gateway Nodes!"); }
    }

    /// <summary>
    /// Connects a Gateway node to a non-gateway node
    /// </summary>
    public void ConnectGatewayNode(int _GW_UID, int _AUID, NodeDirection _ND)
    {
        NavNode? A, B;

        if (
                !Nodes.TryGetValue(_GW_UID, out A) ||
                !Nodes.TryGetValue(_AUID, out B) ||
                Math.Abs((int)_ND) > 2
            )
        { throw new Exception("Node(s) does not exist!"); }

        if (A is GatewayNode GW && B is not GatewayNode)
        {
            GW.ConnectNode(_AUID, _ND);
            B.ConnectNode(_GW_UID, (NodeDirection)((int)_ND * -1));
        }
        else
        { throw new Exception("Wrong configuration of nodes!"); }
    }
    #endregion

    #region Removing Nodes
    /// <summary>
    /// Removes the node with the specified UID. Ignores if node doesn't exist
    /// </summary>
    /// <param name="_UID">Unique ID of the node to remove</param>
    public void RemoveNode(int _UID)
    {
        _UID = Math.Abs(_UID);

        if (DoesNodeExist(_UID))
        {
            NavNode Temp = Nodes[_UID];

            if (Temp is RoomNode RN)
            {
                foreach (var T in RN.Tags)
                { RemoveOrDecrementTag(T); }
            }

            foreach (var KVP in Temp.GetConnectedNodes())
            {
                NavNode? IntTemp = null;

                if (TryGetNode(KVP.Value, out IntTemp) && IntTemp != null)
                { IntTemp.RemoveConnectedNode((NodeDirection)((int)KVP.Key * -1)); }
            }
            Nodes.Remove(_UID);
        }
    }
    #endregion

    #region Popping Nodes
    /// <summary>
    /// Removes the node with the specified UID and returns it. UID WILL NOT WORK AFTER POPPING
    /// </summary>
    /// <param name="_UID">Unique ID of the node to remove & return</param>
    /// <returns>The node if it exists. Otherwise null</returns>
    public NavNode? PopNode(int _UID)
    {
        if (!DoesNodeExist(_UID))
        { return null; }

        NavNode Temp = Nodes[_UID].Clone();

        RemoveNode(_UID);

        return Temp;
    }
    #endregion

    #region Node Checking
    /// <summary>
    /// Gets how many connections this node has (minimum of 0, max of 4)
    /// </summary>
    /// <param name="_UID">UID of the base node to check</param>
    /// <returns>How many connections (between 0-4 inclusive) the base node has</returns>
    public override int NumberOfConnections(int _UID)
    {
        NavNode? Temp;

        Temp = TryGetNode(_UID);

        if (Temp == null)
        { throw new Exception("No node exists with the specified UID!"); }

        //counts how many elements are in the returned dictionary
        return Temp.GetConnectedNodes().Count;
    }

    /// <summary>
    /// Checks if a node exists within the NavGraph
    /// </summary>
    /// <param name="_Node">Node object to find</param>
    /// <returns><c>true</c> if the node exists or <c>false</c> if it doesn't</returns>
    public bool DoesNodeExist(NavNode _Node)
    { return Nodes.Values.Contains(_Node); }

    /// <summary>
    /// Checks if a node exists within the NavGraph and offers it's UID
    /// </summary>
    /// <param name="_Node">Node object to find</param>
    /// <param name="_UID">Returned UID of _Node</param>
    /// <returns><c>true</c> if the node exists or <c>false</c> if it doesn't</returns>
    public bool DoesNodeExist(NavNode _Node, out int _UID)
    {
        _UID = 0;

        foreach (var KVP in Nodes)
        {
            if (KVP.Value == _Node)
            { _UID = KVP.Key; return true; }
        }

        return false;
    }

    /// <summary>
    /// Checks if node with inputted UID exists, if so it does offer the node itself
    /// </summary>
    /// <param name="_UID">UID of node to find</param>
    /// <param name="_Node">The returned node</param>
    /// <returns><c>true</c> if the node exists or <c>false</c> if it doesn't</returns>
    public bool DoesNodeExist(int _UID, out NavNode? _Node)
    {
        _Node = null;

        if (DoesNodeExist(_UID))
        { _Node = Nodes[_UID]; return true; }

        return false;
    }
    #endregion

    #region Misc
    /// <summary>
    /// Goes through every node and cleans it. Primarily removes null connections
    /// </summary>
    public void CleanNodes()
    {
        foreach (var KVP in Nodes)
        {
            foreach (var KVPb in KVP.Value.Nodes)
            {
                if (KVPb.Value == 0)
                { KVP.Value.RemoveConnectedNode(KVPb.Key); }
            }
        }
    }

    private int GenerateNewENGroupID()
        => NextENGroupID;

    public void AssignENGroupID(int _UID)
    {
        if (!DoesNodeExist(_UID))
        { return; }

        ElevationNode EN = Nodes[_UID] as ElevationNode;

        if (EN.ENGroupID == 0)
        {
            if (EN.GetConnectedEN().Count >= 1)
            { EN.ENGroupID = (Nodes[EN.GetConnectedEN().First().Value] as ElevationNode).ENGroupID; }
            else
            { EN.ENGroupID = GenerateNewENGroupID(); }
        }
    }

    #endregion

    #region Tags

    /// <summary>
    /// Returns all tags in the Tags dict
    /// </summary>
    /// <returns>A list of all tags</returns>
    public List<string> GetTags()
    { return Tags.Keys.ToList(); }

    /// <summary>
    /// Adds a tag to the dict
    /// </summary>
    /// <param name="_Tag">Tag to add</param>
    public void AddTag(string _Tag)
    {
        if (Tags.ContainsKey(_Tag))
        { return; }
        else
        { Tags.Add(_Tag, 1); }

        OrderTags();
    }

    /// <summary>
    /// Either adds the tag to the dict, or increments it's quantity if it exists
    /// </summary>
    /// <param name="_Tag">Tag to add or increment</param>
    public void AddOrIncrementTag(string _Tag)
    {
        if (Tags.ContainsKey(_Tag))
        { Tags[_Tag]++; }
        else
        { Tags.Add(_Tag, 1); }

        OrderTags();
    }

    /// <summary>
    /// Either reduces the quantity of a tag, or removes it if it's 0
    /// </summary>
    /// <param name="_Tag">Tag to reduce/remove</param>
    public void RemoveOrDecrementTag(string _Tag)
    {
        if (Tags.ContainsKey(_Tag))
        {
            if (Tags[_Tag] > 1)
            { Tags[_Tag]--; }
            else
            { Tags.Remove(_Tag); }
        }

        OrderTags();
    }

    /// <summary>
    /// Deletes the tag from the dict and iterates through all nodes to remove the tag
    /// </summary>
    /// <param name="_Tag">Tag to remove</param>
    public void DeleteTagAndReferences(string _Tag)
    {
        foreach (var N in Nodes.Values.Where(X => X is RoomNode).Cast<RoomNode>())
        {
            if (N.Tags.Contains(_Tag))
            { N.Tags.Remove(_Tag); }
        }

        Tags.Remove(_Tag);
    }

    /// <summary>
    /// Iterates through all nodes to ensure Tags is up to date
    /// </summary>
    public void UpdateAllTags()
    {
        var SuitableNodes = Nodes.Values
                                        .Where(X => X is RoomNode)
                                        .Cast<RoomNode>();

        foreach (var N in SuitableNodes)
        {
            if (N.Tags is null)
            { continue; }

            foreach (var T in N.Tags)
            { AddOrIncrementTag(T.TrimAndCase()); }
        }
    }

    /// <summary>
    /// Orders the tags alphabetically? might remove
    /// </summary>
    private void OrderTags()
    {
        Tags = Tags
            .OrderBy(X => X.Key)
            .ToDictionary(X => X.Key, Y => Y.Value);
    }
    #endregion

    #region Serialising stuff
    /// <summary>
    /// Takes an input stream and writes data to it
    /// </summary>
    /// <param name="_InputStream">Stream data is to be written to</param>
    public override void Deserialise(Stream _InputStream)
    {
        //generates a StreamReader from the input stream
        using (StreamReader Reader = new StreamReader(_InputStream))
        {
            NGSerialiseTemplate SerData = new NGSerialiseTemplate();

            string Temp = Reader.ReadToEnd();

            JSO = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.Never,
                IncludeFields = true,
                PropertyNameCaseInsensitive = true,
                Converters =
                {new TupleConverterFactory(), new JsonStringEnumConverter
                    (default, true)}
            };

            SerData = JsonSerializer.Deserialize<NGSerialiseTemplate>
                (Temp, JSO);

            Blocks = SerData.NG.Blocks;
            Nodes = SerData.NG.Nodes;
            BaseUID = SerData.NG.BaseUID;
            AvailableUID = SerData.NG.AvailableUID;
        }

        CleanNodes();
        UpdateAllTags();
    }

    /// <summary>
    /// Takes a stream to write data to
    /// </summary>
    /// <param name="_OutputStream">The stream to write to</param>
    /// <param name="_SO">Specify what happens during serialisation</param>
    public void Serialise(Stream _OutputStream, NGSerialiseOptions _SO)
    {
        //generates a stream writer from the input stream 
        using (StreamWriter Writer = new StreamWriter(_OutputStream))
        {
            NGSerialiseTemplate SerData = new NGSerialiseTemplate();

            switch (_SO)
            {
                case NGSerialiseOptions.IncludeMetadata:
                {//include blocks dictionary
                    SerData.NG = this;
                    SerData.Blocks = Blocks;
                    SerData.Nodes = null;

                    JSO = new JsonSerializerOptions()
                    {
                        DefaultIgnoreCondition = JsonIgnoreCondition.Never,
                        IncludeFields = true,
                        WriteIndented = true,
                        PropertyNameCaseInsensitive = true,
                        Converters =
                        {new TupleConverterFactory()}
                    };

                    //uses the stream writer to write the string output of the JSON Serialiser
                    Writer.Write
                    (JsonSerializer.Serialize(SerData, JSO).ToCharArray());

                    break;
                }
                case NGSerialiseOptions.SerialiseForApp:
                default:
                {//just nodes but for App
                    SerData.Nodes = Nodes;

                    JSO = new JsonSerializerOptions()
                    {
                        DefaultIgnoreCondition = JsonIgnoreCondition.Never,
                        IncludeFields = true,
                        WriteIndented = false,
                        PropertyNameCaseInsensitive = true,
                        Converters =
                        {new TupleConverterFactory()}
                    };

                    //uses the stream writer to write the string output of the JSON Serialiser
                    Writer.Write
                    (JsonSerializer.Serialize(SerData.Nodes, JSO).ToCharArray());

                    break;
                }
            }


        }
    }
    #endregion
}

public class ReadonlyNavGraph : Graph<NavNode>
{
    public ReadonlyNavGraph() : base()
    { }

    public override void Deserialise(Stream _InputStream)
    {
        //generates a StreamReader from the input stream and passes it to the JSON deserialiser
        using (StreamReader Reader = new StreamReader(_InputStream))
        {
            JsonSerializerOptions JSO = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.Never,
                IncludeFields = true,
                PropertyNameCaseInsensitive = true,
                Converters =
                {new TupleConverterFactory(), new JsonStringEnumConverter
                    (default, true)}
            };

            Nodes = JsonSerializer.Deserialize<Dictionary<int, NavNode>>(Reader.ReadToEnd(), JSO);
        }
    }

    //why is this here?
    public override int NumberOfConnections(int _UID)
    {
        NavNode? Temp;

        Temp = TryGetNode(_UID);

        if (Temp == null)
        { throw new Exception("No node exists with the specified UID!"); }

        //counts how many elements are in the returned dictionary
        return Temp.GetConnectedNodes().Count;
    }

    public Dictionary<int, NavNode> GatewaysToBlock(string _TargetBlock, string _StartingBlock)
    {
        throw new NotImplementedException();

        var GWs =
                    Nodes
                        .Where(X =>
                            X.Value.BlockName == _StartingBlock &&
                            X.Value is GatewayNode GN &&
                            GN.GetConnectedGateways().ContainsKey(_TargetBlock))
                        .ToDictionary();

        if (GWs.Count() == 0)
        { throw new("Uh oh"); }
    }

    public Dictionary<int, NavNode> GetBlock(string _Block)
        => Nodes
            .Where(X => X.Value.BlockName == _Block)
            .ToDictionary(X => X.Key, Y => Y.Value);

    public Dictionary<int, NavNode> GetFloor(string _Block, int _Floor)
        => Nodes
            .Where(X => X.Value.BlockName == _Block && X.Value.Floor == _Floor)
            .ToDictionary(X => X.Key, Y => Y.Value);

    public Dictionary<int, int> Optimal<T>(NavNode _Origin, string _Block, int _Floor) where T : NavNode
    {
        ISpecialFlow Temp;

        if (_Origin is not ISpecialFlow)
        {
            Temp = _Origin.GetConnectedNodes()
                            .Select(X => Nodes[X.Value])
                            .OfType<ISpecialFlow>()
                            .First();
        }
        else
        { Temp = _Origin as ISpecialFlow; }

        IEnumerable<Dictionary<int, (int Distance, bool IsEN)>?>? F = Temp.Flow.Values;






        throw new NotImplementedException();
    }

    public List<NavNode> GetNodes(IEnumerable<int> _UIDs)
    {
        List<NavNode> T = new();

        foreach (var UID in _UIDs)
        {
            if (DoesNodeExist(UID))
            { T.Add(Nodes[UID]); }
        }

        return T;
    }

    public IEnumerable<T> GetNodes<T>(IEnumerable<int> _UIDs) where T : class, Node
    {
        List<T> Tl = new();

        foreach (var UID in _UIDs)
        {
            if (DoesNodeExist(UID) && Nodes[UID] is T)
            { Tl.Add(Nodes[UID] as T); }
        }

        return Tl.Where(X => X is not null);
    }

    /// <summary>
    /// Gets all the nodes of a particular block.
    /// </summary>
    /// <param name="_Block">Name of blocks to get nodes from</param>
    /// <returns>A dictionary of UIDs and NavNodes</returns>
    public Dictionary<int, NavNode> GetNodes(string _Block)
        => GetAllNodes()
            .Where(X => X.Value.BlockName == _Block)
            .ToDictionary(X => X.Key,
                        Y => Y.Value);

    /// <summary>
    /// Gets all the nodes of a particular floor in a specific block.
    /// </summary>
    /// <param name="_Block">Name of blocks to get nodes from</param>
    /// <param name="_Floor">Floor to get nodes from</param>
    /// <returns>A dictionary of UIDs and NavNodes</returns>
    public Dictionary<int, NavNode> GetNodes(string _Block, int _Floor)
        => GetAllNodes()
            .Where(X =>
                X.Value.BlockName == _Block &&
                X.Value.Floor == _Floor)
            .ToDictionary(X => X.Key,
                        Y => Y.Value);

    /// <summary>
    /// Gets the number of nodes on a particular floor, in a particular block
    /// </summary>
    /// <param name="_Block">Name of blocks to get nodes from</param>
    /// <param name="_Floor">Floor to get nodes from</param>
    /// <returns>A dictionary of UIDs and NavNodes</returns>
    public int GetFloorNodeCount(string _Block, int _Floor)
        => GetNodes(_Block, _Floor).Count();

    public Dictionary<NodeDirection, NavNode>? GetConnectedNodes(NavNode _N, bool NullCheck = false)
    {
        var C = _N.GetConnectedNodes();

        if (NullCheck)
        {
            return C.Where(X => Nodes.ContainsKey(X.Value))
                    .ToDictionary(X => X.Key,
                               Y => Nodes[Y.Value]);
        }
        else
        {
            return C.ToDictionary(X => X.Key,
                Y => Nodes[Y.Value]);
        }
    }

    public Dictionary<NodeDirection, NavNode>? GetConnectedNodes(int _UID, bool NullCheck = false)
    {
        if (Nodes.ContainsKey(_UID))
        { return GetConnectedNodes(Nodes[_UID], NullCheck); }
        else
        { return null; }
    }

    #region Node Checking
    /// <summary>
    /// Checks if a node exists within the NavGraph
    /// </summary>
    /// <param name="_Node">Node object to find</param>
    /// <returns><c>true</c> if the node exists or <c>false</c> if it doesn't</returns>
    public bool DoesNodeExist(NavNode _Node)
    { return Nodes.Values.Contains(_Node); }

    /// <summary>
    /// Checks if a node exists within the NavGraph and offers it's UID
    /// </summary>
    /// <param name="_Node">Node object to find</param>
    /// <param name="_UID">Returned UID of _Node</param>
    /// <returns><c>true</c> if the node exists or <c>false</c> if it doesn't</returns>
    public bool DoesNodeExist(NavNode _Node, out int _UID)
    {
        _UID = 0;

        foreach (var KVP in Nodes)
        {
            if (KVP.Value == _Node)
            { _UID = KVP.Key; return true; }
        }

        return false;
    }

    /// <summary>
    /// Checks if node with inputted UID exists, if so it does offer the node itself
    /// </summary>
    /// <param name="_UID">UID of node to find</param>
    /// <param name="_Node">The returned node</param>
    /// <returns><c>true</c> if the node exists or <c>false</c> if it doesn't</returns>
    public bool DoesNodeExist(int _UID, out NavNode? _Node)
    {
        _Node = null;

        if (DoesNodeExist(_UID))
        { _Node = Nodes[_UID]; return true; }

        return false;
    }
    #endregion
}

public enum NGSerialiseOptions : int
{
    IncludeMetadata = 0,
    SerialiseForApp = 1
}

internal struct NGSerialiseTemplate
{
    [JsonInclude]
    public Dictionary<int, NavNode>? Nodes { get; set; } = null;
    [JsonInclude]
    public Dictionary<string, (int, int)>? Blocks { get; set; } = null;

    [JsonInclude]
    public NavGraph? NG { get; set; } = null;

    public NGSerialiseTemplate()
    {
        Nodes = null;
        Blocks = null;
        NG = null;
    }
}

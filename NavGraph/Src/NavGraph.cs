// Ignore Spelling: Nav UID AUID BUID Deserialise

using System.Text.Json;

namespace NavGraphTools
{
    public class NavGraph : Graph<NavNode>
    {
        #region MemberVariables
        //reserves 50 UIDs for flags and such:
        //UID 0 = no node
        public const int MINIMUM_UID = 25;
        //if uid is negative & < -25, it's a one-way connection
        //for example, if A -> B is one way, A would store B's UID, but B would store the negative of A's UID

        ///For generating new UIDs
        internal int BaseUID = MINIMUM_UID;

        public Dictionary<string, (int Max, int Min)> Blocks = new Dictionary<string, (int Max, int Min)>();
        //                         ^No floors
        //                  ^Block name

        //The next assignable UID
        private int _AvailableUID;
        internal int AvailableUID
        {
            get
            { return _AvailableUID++; }

            set
            { _AvailableUID = value; }
        }
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="GenerateNewGraph">[true] if you're creating a new graph, [false] if you're going to read in data</param>
        public NavGraph(bool GenerateNewGraph) : base(GenerateNewGraph)
        {
            if (GenerateNewGraph)
            {
                Random RND = new Random(((int)DateTime.Now.Ticks));

                //generates a base UID from MINIMUM_UID to 65536
                BaseUID = RND.Next(MINIMUM_UID, 65536);

                _AvailableUID = BaseUID++;
            }
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
            if (Nodes.ContainsKey(_UID))
            {
                Nodes[_UID] = _NewNode;
                return true;
            }
            else
            { return false; }
        }
        #endregion

        #region Connecting Nodes
        /// <summary>
        /// Connects two nodes. Parameters are from the perspective of Node A
        /// </summary>
        /// <param name="_AUID">The UID of Node A</param>
        /// <param name="_BUID">The UID of Node B</param>
        /// <param name="_Direction">Which direction A is connected to B</param>
        /// <param name="_IsOneWay">Whether the connection only goes from A to B</param>
        public void ConnectNodes(int _AUID, int _BUID, NodeDirection _Direction, bool _IsOneWay)
        {
            //checks if both nodes exists
            if ((!DoesNodeExist(_AUID) && !DoesNodeExist(_BUID)))
            { throw new Exception("One or both nodes don't exist!"); }
            else if (
                (Nodes[_AUID] is ElevationNode || Nodes[_BUID] is ElevationNode) ||
                (Nodes[_AUID] is GatewayNode || Nodes[_BUID] is GatewayNode))
            { throw new Exception("Please do not connect Elevation or Gateway nodes with this function"); }
            else if (_Direction == NodeDirection.Up || _Direction == NodeDirection.Down)
            { throw new Exception("_Direction is not valid for this node type"); }

            //connects node B to node A
            Nodes[_AUID].ConnectNode(_BUID, _Direction);

            if (_IsOneWay)
            { Nodes[_BUID].ConnectNode(_AUID * -1, (NodeDirection)((int)_Direction * -1)); }
            else
            { Nodes[_BUID].ConnectNode(_AUID, (NodeDirection)((int)_Direction * -1)); }
        }

        /// <summary>
        /// Connects two elevation nodes either above or below
        /// </summary>
        /// <param name="_AUID">The UID of the Elevation Node A</param>
        /// <param name="_BUID">The UID of the Elevation Node B</param>
        /// <param name="Up">Whether B connects atop A [true] or beneath [false]</param>
        public void ConnectElevationNodes(int _AUID, int _BUID, NodeDirection _Direction)
        {
            NavNode? TempA;
            NavNode? TempB;

            //checks that both nodes exist in the dictionary and grabs the object
            if (!Nodes.TryGetValue(_AUID, out TempA) || !Nodes.TryGetValue(_BUID, out TempB))
            { throw new Exception("Node does not exist!"); }
            else if (TempA is ElevationNode TA && TempB is ElevationNode TB)
            {
                TA.ConnectNode(_BUID, _Direction);
                TB.ConnectNode(_AUID, _Direction);
            }
            else
            { throw new Exception("One or both nodes weren't elevation nodes!"); }
        }

        /// <summary>
        /// Connects two gateway nodes together
        /// </summary>
        /// <param name="_AUID">UID of first node</param>
        /// <param name="_BUID">UID of second node</param>
        public void ConnectGatewayNodes(int _AUID, int _BUID)
        {
            NavNode? A;
            NavNode? B;

            if (!Nodes.TryGetValue(_AUID, out A) || !Nodes.TryGetValue(_BUID, out B))
            { throw new Exception("Node does not exist!"); }

            if (A is GatewayNode TA && B is GatewayNode TB)
            {
                TA.ConnectNode(_BUID, TB.BlockName);
                TB.ConnectNode(_AUID, TA.BlockName);
            }
            else
            { throw new Exception("One or both nodes aren't Gateway Nodes!"); }
        }
        #endregion

        #region Removing Nodes
        /// <summary>
        /// Removes the node with the specified UID. Ignores if node doesn't exist
        /// </summary>
        /// <param name="_UID">Unique ID of the node to remove</param>
        public void RemoveNode(int _UID)
        {
            if (DoesNodeExist(_UID))
            { Nodes.Remove(_UID); }
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
        #endregion

        #region Serialising stuff
        /// <summary>
        /// Takes an input stream and writes data to it
        /// </summary>
        /// <param name="_InputStream">Stream data is to be written to</param>
        public override void Deserialise(Stream _InputStream)
        {
            //generates a StreamReader from the input stream and passes it to the JSON deserialiser
            using (StreamReader Reader = new StreamReader(_InputStream))
            { Nodes = JsonSerializer.Deserialize<Dictionary<int, NavNode>>(Reader.ReadToEnd()); }

            //gets the largets value in the just deserialised group of keys
            BaseUID = Nodes.Keys.Max();

            //asigns the next available UID to the base UID +1
            _AvailableUID = BaseUID + 1;
        }

        /// <summary>
        /// Takes a stream to write data to
        /// </summary>
        /// <param name="_OutputStream">The stream to write to</param>
        public void Serialise(Stream _OutputStream)
        {
            //generates a stream writer from the input stream 
            using (StreamWriter Writer = new StreamWriter(_OutputStream))
            {
                //uses the stream writer to write the string output of the JSON Serialiser
                Writer.Write
                (JsonSerializer.Serialize(Nodes).ToCharArray());
            }
        }
        #endregion
    }

    public class ReadonlyNavGraph : Graph<NavNode>
    {
        public Dictionary<string, (int Max, int Min)> Blocks = new Dictionary<string, (int Max, int Min)>();
        //                         ^No floors
        //                  ^Block name

        public ReadonlyNavGraph() : base()
        { }

        public override void Deserialise(Stream _InputStream)
        {
            //generates a StreamReader from the input stream and passes it to the JSON deserialiser
            using (StreamReader Reader = new StreamReader(_InputStream))
            { Nodes = JsonSerializer.Deserialize<Dictionary<int, NavNode>>(Reader.ReadToEnd()); }
        }

        public override int NumberOfConnections(int _UID)
        {
            NavNode? Temp;

            Temp = TryGetNode(_UID);

            if (Temp == null)
            { throw new Exception("No node exists with the specified UID!"); }

            //counts how many elements are in the returned dictionary
            return Temp.GetConnectedNodes().Count;
        }
    }
}

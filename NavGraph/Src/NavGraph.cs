using System.Text.Json;

namespace NavGraphTools
{
    public class NavGraph
    {
        #region MemberVariables
        //reserves 50 UIDs for flags and such:
        //UID 0 = no node, UID 1 = no entry (1 way)
        public const uint MINIMUM_UID = 50;

        //Internal so *Navigator* has access to it but nothing outside this assembly does
        
        internal Dictionary<uint, NavNode> Nodes = new Dictionary<uint, NavNode>();

        ///For generating new UIDs
        internal uint BaseUID = MINIMUM_UID;

        private uint _AvailableUID;
        internal uint AvailableUID 
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
        public NavGraph(bool GenerateNewGraph)
        {
            if (GenerateNewGraph)
            {
                Random RND = new Random(((int)DateTime.Now.Ticks));

                //generates a base UID from MINIMUM_UID to 134,217,727
                BaseUID = (uint)RND.Next((int)MINIMUM_UID, (int)(uint.MaxValue / 8192));

                _AvailableUID = BaseUID++;
            }
        }

        #region Adding Nodes
        /// <summary>
        /// Adds a node to the dictionary with a randomly assigned UID
        /// </summary>
        /// <param name="_NewNode">The node to be added</param>
        /// <returns>UID if succesful, 0 if it fails</returns>
        public uint AddNode(NavNode _NewNode)
        {
            //auto increments
            uint TempUID = AvailableUID;

            //increments on loop until it finds a new key
            while (Nodes.ContainsKey(TempUID))
            {TempUID = AvailableUID;}

            _NewNode.UID = TempUID;

            Nodes.Add(TempUID, _NewNode);

            return TempUID;

            //Note: it may run for a while possibly if it struggles to find a new key
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
        /// <param name="_Overwrite">If true it will replace any exisiting connections between A and B</param>
        public void ConnectNodes(uint _AUID, uint _BUID, NodeDirection _Direction, bool _IsOneWay, bool _Overwrite)
        {
            if (!DoesNodeExist(_AUID) && !DoesNodeExist(_BUID))
            {throw new Exception("One or both nodes don't exist!");}

            if (_Overwrite ||
                (!Nodes[_AUID].IsConnected(_Direction) && 
                 !Nodes[_BUID].IsConnected((NodeDirection)((int)_Direction * -1))))
            {
                Nodes[_AUID].AddConnectedNode(_BUID, _Direction);

                if (_IsOneWay)
                {Nodes[_BUID].AddConnectedNode(1, (NodeDirection)((int)_Direction * -1));}
                else
                {Nodes[_BUID].AddConnectedNode(_AUID, (NodeDirection)((int)_Direction * -1));}
            }
        }

        /// <summary>
        /// Connects two elevation nodes either above or below
        /// </summary>
        /// <param name="_AUID">The UID of the Elevation Node A</param>
        /// <param name="_BUID">The UID of the Elevation Node B</param>
        /// <param name="Up">Whether B connects atop A [true] or beneath [false]</param>
        public void ConnectElevationNodes(uint _AUID, uint _BUID, bool Up)
        {
            NavNode? TempA;
            NavNode? TempB;

            if (!Nodes.TryGetValue(_AUID, out TempA))
            {throw new Exception("Node does not exist!");}

            if (!Nodes.TryGetValue(_BUID, out TempB))
            {throw new Exception("Node does not exist!");}

            if (TempA is ElevationNode TA && TempB is ElevationNode TB)
            {
                if (Up)
                {
                    TA.Nodes[NodeDirection.Up] = _BUID;
                    TB.Nodes[NodeDirection.Down] = _AUID;
                }
                else
                {
                    TB.Nodes[NodeDirection.Up] = _AUID;
                    TA.Nodes[NodeDirection.Down] = _BUID;
                }
            }
            else
            {throw new Exception("One or both nodes weren't elevation nodes!");}
        }
        #endregion

        #region Removing Nodes
        /// <summary>
        /// Removes the node with the specified UID. Ignores if node doesn't exist
        /// </summary>
        /// <param name="_UID">Unique ID of the node to remove</param>
        public void RemoveNode(uint _UID) 
        {
            if (DoesNodeExist(_UID))
            {Nodes.Remove(_UID);}
        }
        #endregion

        #region Popping Nodes
        /// <summary>
        /// Removes the node with the specified UID and returns it. UID WILL NOT WORK AFTER POPPING
        /// </summary>
        /// <param name="_UID">Unique ID of the node to remove & return</param>
        /// <returns>The node if it exists. Otherwise null</returns>
        public NavNode? PopNode(uint _UID)
        {
            if (!DoesNodeExist(_UID))
            {return null;}

            NavNode Temp = Nodes[_UID].Clone();

            RemoveNode(_UID);

            return Temp;
        }
        #endregion

        #region Getting Nodes
        /// <summary>
        /// Attempts to retreive the node
        /// </summary>
        /// <param name="_UID">Unique ID of the node to get</param>
        /// <returns>Returns the node with the UID or null if it doesn't exist</returns>
        /// <exception cref="NotImplementedException"></exception>
        public NavNode? TryGetNode(uint _UID)
        {
            if (DoesNodeExist(_UID))
            {return Nodes[_UID];}
            else
            {return null;}
        }

        /// <summary>
        /// Gets all the nodes in the graph with their UID
        /// </summary>
        /// <returns>a list of all nodes int the Graph</returns>
        public Dictionary<uint, NavNode> GetAllNodes()
        {return Nodes;}

        #endregion

        #region Node Checking
        /// <summary>
        /// Checks if a node with the specified UI exists
        /// </summary>
        /// <param name="_UID">UID of the node to check</param>
        /// <returns><c>true</c> if the node exists or <c>false</c> if it doesn't</returns>
        public bool DoesNodeExist(uint _UID)
        {
            if (Nodes.ContainsKey(_UID))
            {return true;}
            else
            {return false;}
        }

        /// <summary>
        /// Gets how many connections this node has (minimum of 0, max of 4)
        /// </summary>
        /// <param name="_UID">UID of the base node to check</param>
        /// <returns>How many connections (between 0-4 inclusive) the base node has</returns>
        public uint NumberOfConnections(uint _UID)
        {
            NavNode? Temp;
            uint Counter = 0;

            Temp = TryGetNode(_UID);

            if (Temp == null)
            { throw new Exception("No node exists with the specified UID!"); }

            foreach (KeyValuePair<NodeDirection, uint> N in Temp.Nodes)
            {
                if (N.Value > MINIMUM_UID)
                {Counter++;}
            }

            return Counter;
        }


        public int CountNodes()
        {return Nodes.Count;}
        #endregion

        #region Serialising stuff
        public void Deserialise(Stream _InputStream)
        {
            using (StreamReader Reader = new StreamReader(_InputStream))
            {Nodes = JsonSerializer.Deserialize<Dictionary<uint, NavNode>>(Reader.ReadToEnd());}

            //gets the largets value in the just deserialised group of keys
            BaseUID = Nodes.Keys.Max();

            _AvailableUID = BaseUID + 1;
        }

        public void Serialise(Stream _OutputStream) 
        {
            using (StreamWriter Writer = new StreamWriter(_OutputStream))
            {
                Writer.Write
                (JsonSerializer.Serialize<Dictionary<uint, NavNode>>(Nodes).ToCharArray());
            }
        }
        #endregion
    }

    public class Navigator
    {
        private NavNode StartNode { get; set; }
        private NavNode DestinationNode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartNodeUID">The UID of the node to start from</param>
        /// <param name="DestNodeUID">The UID of the destination node</param>
        /// <param name="_NG">The navgraph object to navigate</param>
        /// <returns>A list of nodes in order to travel from Start to End</returns>
        public List<NavNode> StartNavigation(uint StartNodeUID, uint DestNodeUID, ref NavGraph _NG)
        {
            //navigate

            throw new NotImplementedException();
        }
    }
}

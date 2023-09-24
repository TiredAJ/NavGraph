using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

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

    [JsonSerializable(typeof(NavNode))]
    [JsonDerivedType(typeof(NavNode), typeDiscriminator:"base")]
    [JsonDerivedType(typeof(RoomNode), typeDiscriminator:"Room")]
    [JsonDerivedType(typeof(ElevationNode), typeDiscriminator:"Elevation")]
    public class NavNode
    {
        public NavNode()
        {}

        [JsonInclude]
        public uint UID { get; internal set; } = 0;
        public string BlockPrefix { get; set; }
        public string BlockName { get; set; }
        public string Floor { get; set; }        
        public virtual string InternalName { get; set; } = "Default Node";
        [JsonInclude]
        public virtual ListDictionary Nodes { get; internal set; } = new ListDictionary() 
        {
            {NodeDirection.North, 0 },
            {NodeDirection.East, 0 },
            {NodeDirection.South, 0 },
            {NodeDirection.West, 0 },
        };

        public void AddConnectedNode(uint _NodeUID, NodeDirection _Direction)
        {Nodes[_Direction] = _NodeUID;}

        public void RemoveConnectedNode(NodeDirection _Direction)
        {Nodes[_Direction] = 0;}

        public uint GetNode(NodeDirection _Direction)
        {return (uint)Nodes[_Direction];}

        /// <summary>
        /// Gets a dictionary containing all connected nodes
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<NodeDirection, uint> GetConnectedNodes()
        {
            Dictionary<NodeDirection, uint> Temp = new Dictionary<NodeDirection, uint>();

            foreach (KeyValuePair<NodeDirection, uint> N in ToDictionary(Nodes))
            {
                if (N.Value >= NavGraph.MINIMUM_UID || N.Value == 1)
                {Temp.Add(N.Key, N.Value);}
            }

            return Temp;
        }

        /// <summary>
        /// Checks if a node's connected on the given direction
        /// </summary>
        /// <param name="_Direction">The NodeDirection to check</param>
        /// <returns>[true] if something's connected, else [false]</returns>
        public bool IsConnected(NodeDirection _Direction)
        {
            if ((uint)Nodes[_Direction] > 0)
            {return true;}
            else
            {return false;}
        }

        /// <summary>
        /// Clones the object
        /// </summary>
        /// <returns>A copy of the object</returns>
        public NavNode Clone()
        {return (NavNode)this.MemberwiseClone();}

        /// <summary>
        /// Use to convert wacky ListDictionarys to proper Dictionarys
        /// </summary>
        /// <param name="_Dict">Input ListDictionary</param>
        /// <returns>Peroperly formatted Dictionary</returns>
        public static Dictionary<NodeDirection, uint> ToDictionary(ListDictionary _Dict)
        {
            Dictionary<NodeDirection, uint> Temp = new Dictionary<NodeDirection, uint>();

            foreach (DictionaryEntry DE in _Dict)
            {Temp.Add((NodeDirection)DE.Key, (uint)DE.Value);}

            return Temp;
        }

        public override string ToString()
        {
            return $"UID: {UID}, Internal name: {InternalName}, Connections: " +
                $"(N: {(uint)Nodes[NodeDirection.North]}), (E: {(uint)Nodes[NodeDirection.East]}), " +
                $"(S: {(uint)Nodes[NodeDirection.South]}), (W: {(uint)Nodes[NodeDirection.West]})";
        }
    }

    [JsonSerializable(typeof(RoomNode))]
    public class RoomNode : NavNode
    {
        public override string InternalName { get; set; } = "Default Room";
        public string RoomName { get; set; }

        [ListStringLength(50, true)]
        public List<string> Tags { get; set; }

        public override string ToString()
        {return base.ToString() + $", Room name: {RoomName}";}
    }

    [JsonSerializable(typeof(ElevationNode))]
    public class ElevationNode : NavNode
    {
        public override string InternalName { get; set; } = "Default Elevation";

        [JsonInclude]
        public override ListDictionary Nodes { get; internal set; } = new ListDictionary()
        {
            {NodeDirection.North, 0 },
            {NodeDirection.East, 0 },
            {NodeDirection.South, 0 },
            {NodeDirection.West, 0 },
            {NodeDirection.Up, 0 },
            {NodeDirection.Down, 0 },
        };

        public override Dictionary<NodeDirection, uint> GetConnectedNodes()
        {
            Dictionary<NodeDirection, uint> Temp = new Dictionary<NodeDirection, uint>();

            foreach (KeyValuePair<NodeDirection, uint> N in ToDictionary(Nodes))
            {
                if (N.Value >= NavGraph.MINIMUM_UID || N.Value == 1)
                {Temp.Add(N.Key, N.Value);}
            }

            return Temp;
        }

        public override string ToString()
        {
            return base.ToString() + $", Up connection: {(uint)Nodes[NodeDirection.Up]}," +
                $" Down connection: {(uint)Nodes[NodeDirection.Down]}";
        }
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

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    internal sealed class ListStringLength : ValidationAttribute
    {
        readonly int _Length;
        readonly bool _Trim;

        public int Length
        {get => _Length;}
        public bool Trim
        {get => _Trim;}

        /// <summary>
        /// Constructor for Attribute
        /// </summary>
        /// <param name="_Len">Maximum string length for each element</param>
        /// <param name="_Trim">Whether elements should be trimmed to size or an exception thrown when out of size</param>
        public ListStringLength(uint _Len, bool _Trim)
        {
            _Length = (int)_Len;
            this._Trim = _Trim;
        }

        public override bool IsValid(object? _Value)
        {
            bool Result = true;

            var Value = _Value as List<string>;

            if (Value == null)
            {throw new ArgumentException("Property/Field must be a list of strings!");}

            if (Trim)
            {Value.Select(S => TrimStr(S));}
            else
            {Result = Value.All(S => S.Length <= Length);}

            return Result;
        }

        private string TrimStr(string _Input)
        {
            if (_Input.Length > Length)
            {return _Input.Substring(0, Length);}
            else 
            {return _Input;}
        }
    }

    public enum NodeDirection
    {
        North = 1,
        East = 2,
        South = -1,
        West = -2,
        Up = 3,
        Down = -3
    }
}

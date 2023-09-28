using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NavGraphTools.Src
{
    [JsonSerializable(typeof(NavNode))]
    [JsonDerivedType(typeof(NavNode), typeDiscriminator: "base")]
    [JsonDerivedType(typeof(RoomNode), typeDiscriminator: "Room")]
    [JsonDerivedType(typeof(ElevationNode), typeDiscriminator: "Elevation")]
    [JsonDerivedType(typeof(CorridorNode), typeDiscriminator: "Corridor")]
    [JsonDerivedType(typeof(PredefinedNode), typeDiscriminator: "Predefined")]
    public abstract class NavNode
    {
        public NavNode()
        { }

        #region Member Variables
        [JsonInclude]
        public int UID { get; internal set; } = 0;
        public string BlockPrefix { get; set; } = "J";
        public string BlockName { get; set; } = "Johnstone";
        public string Floor { get; set; } = "Ground";
        public virtual string InternalName { get; set; } = "Default Node";
        [JsonInclude]
        public virtual Dictionary<NodeDirection, int> Nodes { get; internal set; } = new Dictionary<NodeDirection, int>(4);
        #endregion

        #region Altering Connections
        public void AddConnectedNode(int _NodeUID, NodeDirection _Direction)
        { Nodes[_Direction] = _NodeUID; }

        public void RemoveConnectedNode(NodeDirection _Direction)
        { Nodes[_Direction] = 0; }
        #endregion

        #region Getting Connections
        public int GetNode(NodeDirection _Direction)
        { return (int)Nodes[_Direction]; }

        /// <summary>
        /// Gets a dictionary containing all connected nodes
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<NodeDirection, int> GetConnectedNodes()
        {
            Dictionary<NodeDirection, int> Temp = new Dictionary<NodeDirection, int>();

            foreach (KeyValuePair<NodeDirection, int> N in Nodes)
            {
                if (N.Value >= NavGraph.MINIMUM_UID || N.Value <= -25)
                { Temp.Add(N.Key, N.Value); }
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
            if ((int)Nodes[_Direction] > 0)
            { return true; }
            else
            { return false; }
        }
        #endregion

        #region Misc
        /// <summary>
        /// Clones the object
        /// </summary>
        /// <returns>A copy of the object</returns>
        public NavNode Clone()
        { return (NavNode)this.MemberwiseClone(); }

        public override string ToString()
        {
            return $"UID: {UID}, Internal name: {InternalName}, Connections: " +
                $"(N: {(int)Nodes[NodeDirection.North]}), (E: {(int)Nodes[NodeDirection.East]}), " +
                $"(S: {(int)Nodes[NodeDirection.South]}), (W: {(int)Nodes[NodeDirection.West]})";
        }
        #endregion
    }

    [JsonSerializable(typeof(CorridorNode))]
    public class CorridorNode : NavNode
    {
        [JsonInclude]
        [DictionaryDirection(NodeDirection.North | NodeDirection.East | NodeDirection.South | NodeDirection.West)]
        public override Dictionary<NodeDirection, int> Nodes { get; internal set; } = new Dictionary<NodeDirection, int>()
        {
            {NodeDirection.North, 0 },
            {NodeDirection.East, 0 },
            {NodeDirection.South, 0 },
            {NodeDirection.West, 0 }
        };
    }

    [JsonSerializable(typeof(RoomNode))]
    public class RoomNode : NavNode
    {
        #region Member Variables
        public override string InternalName { get; set; } = "Default Room";
        public string RoomName { get; set; } = "Default Room Name";

        [DictionaryDirection(NodeDirection.North | NodeDirection.East | NodeDirection.South | NodeDirection.West)]
        public override Dictionary<NodeDirection, int> Nodes { get; internal set; } = new Dictionary<NodeDirection, int>()
        {
            {NodeDirection.North, 0 },
            {NodeDirection.East, 0 },
            {NodeDirection.South, 0 },
            {NodeDirection.West, 0 }
        };

        [ListStringLength(50, true)]
        public List<string> Tags { get; set; } = new List<string>();
        #endregion

        #region Misc
        public override string ToString()
        { return base.ToString() + $", Room name: {RoomName}"; }
        #endregion
    }

    [JsonSerializable(typeof(ElevationNode))]
    public class ElevationNode : NavNode
    {
        #region Member Variables
        public override string InternalName { get; set; } = "Default Elevation";

        [JsonInclude]
        [DictionaryDirection(NodeDirection.North | NodeDirection.East | NodeDirection.South | 
            NodeDirection.West | NodeDirection.Up | NodeDirection.South)]
        public override Dictionary<NodeDirection, int> Nodes { get; internal set; } = new Dictionary<NodeDirection, int>(6)
        {
            {NodeDirection.North, 0 },
            {NodeDirection.East, 0 },
            {NodeDirection.South, 0 },
            {NodeDirection.West, 0 },
            {NodeDirection.Up, 0 },
            {NodeDirection.Down, 0 },
        };
        #endregion

        #region Getting Connections
        public override Dictionary<NodeDirection, int> GetConnectedNodes()
        {
            Dictionary<NodeDirection, int> Temp = new Dictionary<NodeDirection, int>();

            foreach (KeyValuePair<NodeDirection, int> N in Nodes)
            {
                if (N.Value >= NavGraph.MINIMUM_UID || N.Value <= -25)
                { Temp.Add(N.Key, N.Value); }
            }

            return Temp;
        }
        #endregion

        #region Misc
        public override string ToString()
        {
            return base.ToString() + $", Up connection: {Nodes[NodeDirection.Up]}," +
                $" Down connection: {Nodes[NodeDirection.Down]}";
        }
        #endregion
    }

    [JsonSerializable(typeof(PredefinedNode))]
    public class PredefinedNode : NavNode
    {
        #region Member Variables
        [JsonInclude]
        [DictionaryDirection(NodeDirection.A | NodeDirection.B)]
        public override Dictionary<NodeDirection, int> Nodes { get; internal set; } = new Dictionary<NodeDirection, int>()
        {
            {NodeDirection.A, 0 },
            {NodeDirection.B, 0 },
        };

        //Awaiting implementation
        //public int RouteReference;
        #endregion

        #region Misc
        public override string ToString()
        {
            return base.ToString() + $", Connection A: {Nodes[NodeDirection.A]}," +
                $" Connection B: {Nodes[NodeDirection.Down]}";
        }
        #endregion
    }

    #region Attributes

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    internal sealed class ListStringLength : ValidationAttribute
    {
        #region Member Variables
        readonly int _Length;
        readonly bool _Trim;

        public int Length
        { get => _Length; }
        public bool Trim
        { get => _Trim; }
        #endregion

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
            { throw new ArgumentException("Property/Field must be a list of strings!"); }

            if (Trim)
            { Value.Select(S => TrimStr(S)); }
            else
            { Result = Value.All(S => S.Length <= Length); }

            return Result;
        }

        private string TrimStr(string _Input)
        {
            if (_Input.Length > Length)
            { return _Input.Substring(0, Length); }
            else
            { return _Input; }
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    internal sealed class DictionaryDirection : ValidationAttribute
    {
        List<NodeDirection> AllowedDirections = new List<NodeDirection>();

        public DictionaryDirection(params NodeDirection[] _AllowedDirections)
        {AllowedDirections = _AllowedDirections.ToList();}

        public override bool IsValid(object? _Value)
        {
            if (_Value == null && !(AllowedDirections.Contains((NodeDirection)_Value)))
            {return false;}
            else
            {return true;}
        }
    }
    #endregion

    public enum NodeDirection
    {
        North = 1,
        East = 2,
        South = -1,
        West = -2,
        Up = 3,
        Down = -3,
        A = 4,
        B = -4
    }
}

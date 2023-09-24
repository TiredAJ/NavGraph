using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NavGraphTools
{
    [JsonSerializable(typeof(NavNode))]
    [JsonDerivedType(typeof(NavNode), typeDiscriminator: "base")]
    [JsonDerivedType(typeof(RoomNode), typeDiscriminator: "Room")]
    [JsonDerivedType(typeof(ElevationNode), typeDiscriminator: "Elevation")]
    public class NavNode
    {
        public NavNode()
        { }

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
        { Nodes[_Direction] = _NodeUID; }

        public void RemoveConnectedNode(NodeDirection _Direction)
        { Nodes[_Direction] = 0; }

        public uint GetNode(NodeDirection _Direction)
        { return (uint)Nodes[_Direction]; }

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
            if ((uint)Nodes[_Direction] > 0)
            { return true; }
            else
            { return false; }
        }

        /// <summary>
        /// Clones the object
        /// </summary>
        /// <returns>A copy of the object</returns>
        public NavNode Clone()
        { return (NavNode)this.MemberwiseClone(); }

        /// <summary>
        /// Use to convert wacky ListDictionarys to proper Dictionarys
        /// </summary>
        /// <param name="_Dict">Input ListDictionary</param>
        /// <returns>Peroperly formatted Dictionary</returns>
        public static Dictionary<NodeDirection, uint> ToDictionary(ListDictionary _Dict)
        {
            Dictionary<NodeDirection, uint> Temp = new Dictionary<NodeDirection, uint>();

            foreach (DictionaryEntry DE in _Dict)
            { Temp.Add((NodeDirection)DE.Key, (uint)DE.Value); }

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
        { return base.ToString() + $", Room name: {RoomName}"; }
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
                { Temp.Add(N.Key, N.Value); }
            }

            return Temp;
        }

        public override string ToString()
        {
            return base.ToString() + $", Up connection: {(uint)Nodes[NodeDirection.Up]}," +
                $" Down connection: {(uint)Nodes[NodeDirection.Down]}";
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    internal sealed class ListStringLength : ValidationAttribute
    {
        readonly int _Length;
        readonly bool _Trim;

        public int Length
        { get => _Length; }
        public bool Trim
        { get => _Trim; }

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

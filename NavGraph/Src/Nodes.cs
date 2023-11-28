// Ignore Spelling: Nav UID Elv

using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using System.Text.Json.Serialization;

namespace NavGraphTools
{
    #region Abstract & Interface
    #region JSON attributes
    [JsonSerializable(typeof(NavNode))]
    //[JsonDerivedType(typeof(NavNode), typeDiscriminator: "base")]
    [JsonDerivedType(typeof(RoomNode), typeDiscriminator: "Room")]
    [JsonDerivedType(typeof(ElevationNode), typeDiscriminator: "Elevation")]
    [JsonDerivedType(typeof(CorridorNode), typeDiscriminator: "Corridor")]
    [JsonDerivedType(typeof(GatewayNode), typeDiscriminator: "Gateway")]
    #endregion
    public abstract class NavNode
    {
        public NavNode()
        { }

        #region Member Variables
        [JsonInclude]
        public int UID { get; internal set; } = 0;
        public string BlockName { get; set; } = "Default Block";
        public int Floor { get; set; } = 0;
        public virtual string InternalName { get; set; } = "Default Node";

        [JsonInclude]
        public virtual Dictionary<NodeDirection, int> Nodes { get; internal set; } = new Dictionary<NodeDirection, int>(4);
        public NodeDirection? ElvNodeDirection { get; set; }
        public NodeDirection? GatewayNodeDirection { get; set; }
        #endregion

        #region Altering Connections
        internal virtual void ConnectNode(int _NodeUID, NodeDirection _Direction)
        {
            if (_Direction != NodeDirection.Up && _Direction != NodeDirection.Down)
            { Nodes[_Direction] = _NodeUID; }
        }

        internal virtual void RemoveConnectedNode(NodeDirection _Direction)
        {
            if (_Direction != NodeDirection.Up && _Direction != NodeDirection.Down)
            { Nodes[_Direction] = 0; }
        }
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

        /// <summary>
        /// Checks if a UID is connected on any direction
        /// </summary>
        /// <param name="_UID">The UID to check</param>
        /// <returns>[true] if it is connected, else [false]</returns>
        public bool IsConnected(int _UID)
        {
            if (Nodes.ContainsValue(_UID))
            { return true; }
            else
            { return false; }
        }

        /// <summary>
        /// Checks if a node can connect on this direction
        /// </summary>
        /// <param name="_Direction"></param>
        /// <returns><see langword="true"/> if available, <see langword="false"/> otherwise</returns>
        public virtual bool IsAvailable(NodeDirection _Direction)
        {
            if (_Direction == NodeDirection.Up || _Direction == NodeDirection.Down)
            { return false; }
            else if (Nodes[_Direction] == 0)
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

        /// <summary>
        /// Checks if UID isn't a flag UID
        /// </summary>
        /// <returns><see langword="true"/> if UID isn't a flag, <see langword="false"/> otherwise</returns>
        public static bool IsValidUID(int _UID)
        {
            if (_UID > NavGraph.MINIMUM_UID)
            { return true; }
            else if (_UID < (NavGraph.MINIMUM_UID * -1))
            { return true; }
            else
            { return false; }
        }

        public override string ToString()
        {
            return $"UID: {UID}, InternalNode name: {InternalName}, Connections: " +
                $"(N: {(int)Nodes[NodeDirection.North]}), (E: {(int)Nodes[NodeDirection.East]}), " +
                $"(S: {(int)Nodes[NodeDirection.South]}), (W: {(int)Nodes[NodeDirection.West]})";
        }
        #endregion
    }

    /// <summary>
    /// DO NOT USE. It's just so I can use a where constraint on Elv & Gateway
    /// </summary>
    public interface ISpecialNodes
    { }
    #endregion

    #region Derived nodes
    [JsonSerializable(typeof(CorridorNode))]
    public class CorridorNode : NavNode
    {
        [JsonInclude]
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

        [JsonInclude]
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

        #region Overrides
        public override string ToString()
        { return base.ToString() + $", Room name: {RoomName}"; }

        #endregion
    }

    [JsonSerializable(typeof(ElevationNode))]
    public class ElevationNode : NavNode, ISpecialNodes
    {
        #region Member Variables
        public override string InternalName { get; set; } = "Default Elevation";

        [JsonInclude]
        public override Dictionary<NodeDirection, int> Nodes { get; internal set; } = new Dictionary<NodeDirection, int>(6)
        {
            {NodeDirection.North, 0 },
            {NodeDirection.East, 0 },
            {NodeDirection.South, 0 },
            {NodeDirection.West, 0 },
            {NodeDirection.Up, 0 },
            {NodeDirection.Down, 0 },
        };
        public new NodeDirection? ElvNodeDirection { get => null; }
        #endregion

        #region Connections
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

        #region Overrides
        public override string ToString()
        {
            return base.ToString() + $", Up connection: {Nodes[NodeDirection.Up]}," +
                $" Down connection: {Nodes[NodeDirection.Down]}";
        }

        /// <summary>
        /// Checks if a node can connect on this direction (includes up/down)
        /// </summary>
        /// <param name="_Direction">Direction to check</param>
        /// <returns><see langword="true"/> if available, <see langword="false"/> otherwise</returns>
        public override bool IsAvailable(NodeDirection _Direction)
        {
            if (Nodes[_Direction] == 0)
            { return true; }
            else
            { return false; }
        }

        internal override void ConnectNode(int _NodeUID, NodeDirection _Direction)
        { Nodes[_Direction] = _NodeUID; }

        internal override void RemoveConnectedNode(NodeDirection _Direction)
        { Nodes[_Direction] = 0; }
        #endregion
    }

    [JsonSerializable(typeof(GatewayNode))]
    public class GatewayNode : NavNode, ISpecialNodes
    {
        #region Member Variables        
        //Throws exception because Nodes shouldn't be used for gateways
        public override Dictionary<NodeDirection, int> Nodes { get => throw new Exception(); }

        [JsonInclude]
        //why is this an <int, string> dictionary?
        public Dictionary<int, string> Connections = new Dictionary<int, string>();
        //                      ^Block name?
        //                 ^gateway UID?
        public new NodeDirection? GatewayNodeDirection { get => null; }
        #endregion

        #region Overrides
        /// <summary>
        /// Gets connected block gateways
        /// </summary>
        /// <returns></returns>
        public new Dictionary<int, string> GetConnectedNodes()
        {
            return Connections.Where(X => IsValidUID(X.Key)).ToDictionary
                (X => X.Key, X => X.Value);
        }

        public override string ToString()
        {
            StringBuilder SB = new StringBuilder();

            foreach (var CN in Connections)
            { SB.Append($"Block: {CN.Key}, UID: {CN.Value}\n"); }

            return SB.ToString();
        }

        /// <summary>
        /// ALWAYS RETURNS FALSE
        /// </summary>
        /// <returns>False, unless cosmic bitflip or some shit</returns>
        public override bool IsAvailable(NodeDirection _Direction)
        { return false; }

        public new bool IsConnected(int _UID)
        {
            if (Connections.ContainsKey(_UID))
            { return true; }
            else
            { return false; }
        }

        internal void ConnectNode(int _NodeUID, string _BlockName)
        {
            if (Connections.ContainsKey(_NodeUID))
            { Connections[_NodeUID] = _BlockName; }
            else
            { Connections.Add(_NodeUID, _BlockName); }
        }

        internal void RemoveConnectedNode(int _NodeUID)
        {
            if (Connections.ContainsKey(_NodeUID))
            { Connections.Remove(_NodeUID); }
        }
        #endregion
    }
    #endregion

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
        { AllowedDirections = _AllowedDirections.ToList(); }

        public override bool IsValid(object? _Value)
        {
            if (_Value == null && !(AllowedDirections.Contains((NodeDirection)_Value)))
            { return false; }
            else
            { return true; }
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
    }
}

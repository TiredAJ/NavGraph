// Ignore Spelling: Nav UID Elv

using NavGraphTools.Utilities;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace NavGraphTools;

/// <summary>
/// Base NavNode object
/// </summary>
#region Abstract & Interface
#region JSON attributes
[JsonSerializable(typeof(NavNode))]
[JsonDerivedType(typeof(RoomNode), typeDiscriminator: "RN")]
[JsonDerivedType(typeof(ElevationNode), typeDiscriminator: "EN")]
[JsonDerivedType(typeof(CorridorNode), typeDiscriminator: "CN")]
[JsonDerivedType(typeof(GatewayNode), typeDiscriminator: "GW")]
#endregion
public abstract class NavNode : Node
{
    public NavNode()
    { }

    #region Member Variables
    /// <summary>
    /// The Unique ID of this node
    /// </summary>
    [JsonInclude]
    public int UID { get; internal set; } = 0;

    /// <summary>
    /// The name of the block this node is in
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("BNm")]
    public string BlockName { get; set; } = "Default Block";

    /// <summary>
    /// The floor number this node is on
    /// </summary>
    [JsonInclude]
    public int Floor { get; set; } = 0;

    /// <summary>
    /// The internal (admin-facing) name of this node
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("IntNm")]
    public virtual string InternalName { get; set; } = "Default Node";

    /// <summary>
    /// The number of nodes this is connected to
    /// </summary>
    [JsonIgnore]
    public virtual int ConnectedNodesCount
    {
        get { return Nodes.Count; }
    }

    /// <summary>
    /// The connections of this node
    /// </summary>
    [JsonInclude]
    public virtual Dictionary<NodeDirection, int> Nodes { get; internal set; } = new Dictionary<NodeDirection, int>();
    #endregion

    #region Altering Connections
    internal virtual void ConnectNode(int _UID, NodeDirection _Dir)
    {
        if (_Dir is (NodeDirection.Up or NodeDirection.Down) || _UID == 0)
        { return; }

        if (!Nodes.ContainsKey(_Dir))
        { Nodes.Add(_Dir, _UID); }
        else
        { Nodes[_Dir] = _UID; }
    }

    internal virtual void RemoveConnectedNode(NodeDirection _Dir)
    {
        if (Nodes.ContainsKey(_Dir))
        { Nodes.Remove(_Dir); }
    }
    #endregion

    #region Getting Connections
    public int GetNode(NodeDirection _Dir)
    { return Nodes.ContainsKey(_Dir) ? Nodes[_Dir] : 0; }

    /// <summary>
    /// Gets a dictionary containing all connected nodes
    /// </summary>
    /// <returns></returns>
    public virtual Dictionary<NodeDirection, int> GetConnectedNodes()
    {
        Dictionary<NodeDirection, int> Temp = new Dictionary<NodeDirection, int>();

        foreach (KeyValuePair<NodeDirection, int> N in Nodes)
        {
            if (Math.Abs(N.Value) > NavGraph.MINIMUM_UID)
            { Temp.Add(N.Key, N.Value); }
        }

        return Temp;
    }

    /// <summary>
    /// Checks if a node's connected on the given direction
    /// </summary>
    /// <param name="_Dir">The NodeDirection to check</param>
    /// <returns>[true] if something's connected, else [false]</returns>
    public bool IsConnected(NodeDirection _Dir)
    {
        if (!Nodes.ContainsKey(_Dir))
        { return false; }

        return Math.Abs(Nodes[_Dir]) > NavGraph.MINIMUM_UID;
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
    /// <param name="_Dir"></param>
    /// <returns><see langword="true"/> if available, <see langword="false"/> otherwise</returns>
    public virtual bool IsAvailable(NodeDirection _Dir)
    {
        if (_Dir is (NodeDirection.Up or NodeDirection.Down))
        { return false; }

        if (!Nodes.ContainsKey(_Dir))
        { return true; }

        return Math.Abs(Nodes[_Dir]) < NavGraph.MINIMUM_UID;
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
    { return Math.Abs(_UID) > NavGraph.MINIMUM_UID; }

    public override string ToString()
    {
        StringBuilder SB = new();

        SB.Append($"UID: {UID}, Internal name: {InternalName}");
        SB.Append(", Connections: ");


        foreach (var KVP in Nodes)
        { SB.Append($"({KVP.Key.Identifier()}: {Nodes[KVP.Key]}), "); }

        return SB.ToString();
    }
    #endregion
}

/// <summary>
/// Marks ElevationNodes and GatewayNodes
/// </summary>
public interface ISpecialNode : Node
{ }

/// <summary>
/// Interface for Flow directions & navigation implementation
/// </summary>
public interface ISpecialFlow : Node
{
    [JsonIgnore]
    public Dictionary<NodeDirection, Dictionary<int, (int Distance, bool IsEN)>>? Flow { get; internal set; }

    /// <summary>
    /// Gets all the flow directions to <see langword="ElevationNode"/>s
    /// </summary>
    /// <returns>A dictionary of <see langword="NodeDirection"/>s and tuples of <see langword="ElevationNode"/>s
    /// and their distance from this Node</returns>
    public Dictionary<NodeDirection, Dictionary<int, int>>? GetElevationNodes()
    => Flow
        .Where(X =>
            X.Value.Any(Y => Y.Value.IsEN == true))
        .ToDictionary(X => X.Key,
            Y => Y.Value
                .ToDictionary(X => X.Key,
                    Y => Y.Value.Distance));

    /// <summary>
    /// Gets all the flow directions to <see langword="GatewayNode"/>s
    /// </summary>
    /// <returns>A dictionary of <see langword="NodeDirection"/>s and tuples of <see langword="GatewayNode"/>s
    /// and their distance from this Node</returns>
    public Dictionary<NodeDirection, Dictionary<int, int>>? GetGatewayNodes()
    => Flow
        .Where(X =>
            X.Value.Any(Y => Y.Value.IsEN == false))
        .ToDictionary(X => X.Key,
            Y => Y.Value
                .ToDictionary(X => X.Key,
                    Y => Y.Value.Distance));

    /// <summary>
    /// Gets the direction to the inputted _UID
    /// </summary>
    /// <param name="_UID">_UID of requested node</param>
    /// <returns>A <see langword="NodeDirection"/> towards the requested node</returns>
    public NodeDirection? GetDirection(int _UID)
    {
        if (Flow != null)
        {
            return Flow
                    .Where(X
                        => X.Value.ContainsKey(_UID))
                    .Select(Z => Z.Key)
                    .First();
        }
        else
        { return null; }
    }

    public bool ContainsUID(int _UID)
    {
        if (Flow == null)
        { return false; }

        return Flow.Values
                    .Any(X =>
                        X.ContainsKey(_UID));
    }

    public void Add(bool _IsEN, NodeDirection _Dir, int _UID, int _Distance)
    {
        if (Flow is not null)
        {
            if (!Flow.ContainsKey(_Dir))
            { Flow.Add(_Dir, new() { { _UID, (_Distance, _IsEN) } }); }
            else if (!Flow[_Dir].ContainsKey(_UID))
            { Flow[_Dir].Add(_UID, (_Distance, _IsEN)); }
        }
        else
        {
            Flow = new()
            {{ _Dir, new() { { _UID, (_Distance, _IsEN) } } }};
        }
    }

    public void ClearFlow()
    { Flow = null; }

    public bool Connected_GW(out IEnumerable<int>? _UIDs)
    {
        var T = Connected(false);

        _UIDs = T.UIDs;

        return T.DoesContain;
    }

    public bool Connected_EN(out IEnumerable<int>? _UIDs)
    {
        var T = Connected(true);

        _UIDs = T.UIDs;

        return T.DoesContain;
    }

    private (bool DoesContain, IEnumerable<int>? UIDs) Connected(bool _Q_EN)
    {
        List<int>? Temp = new List<int>();

        foreach (var T in Flow.Values)
        {
            foreach (var KVP in T)
            {
                if (KVP.Value.IsEN == _Q_EN)
                { Temp.Add(KVP.Key); }
            }
        }

        return (Temp.Count > 0 ? true : false, Temp);
    }


}
#endregion


#region Derived nodes
[JsonSerializable(typeof(CorridorNode))]
public class CorridorNode : NavNode, ISpecialFlow
{
    public CorridorNode() : base()
    { }

    /// <summary>
    /// The number of nodes this is connected to
    /// </summary>
    [JsonIgnore]
    public override int ConnectedNodesCount
    {
        get { return Nodes.Count; }
    }

    [JsonInclude]
    public override Dictionary<NodeDirection, int> Nodes { get; internal set; } = new();

    /// <summary>
    /// The Flow directions for this node
    /// </summary>
    [JsonInclude]
    public Dictionary<NodeDirection, Dictionary<int, (int Distance, bool IsEN)>>? Flow { get; set; }
}


[JsonSerializable(typeof(RoomNode))]
public class RoomNode : NavNode
{
    #region Member Variables
    [JsonInclude]
    [JsonPropertyName("IntNm")]
    public override string InternalName { get; set; } = "Default Room";

    /// <summary>
    /// The public (user-facing) name of this node
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("RNm")]
    public string RoomName { get; set; } = "Default Room Name";

    [JsonInclude]
    public override Dictionary<NodeDirection, int> Nodes { get; internal set; } = new Dictionary<NodeDirection, int>();

    /// <summary>
    /// The number of nodes this is connected to
    /// </summary>
    [JsonIgnore]
    public override int ConnectedNodesCount { get => Nodes.Count(); }

    /// <summary>
    /// The tags relating to this node
    /// </summary>
    [ListStringLength(50, true)]
    public List<string>? Tags { get; set; } = null;
    #endregion

    #region Overrides
    public override string ToString()
    {
        StringBuilder SB = new();

        SB.Append($"UID: {UID}, Internal name: {InternalName}");
        SB.Append($", Public name: {RoomName}, Connections: ");

        foreach (var KVP in Nodes)
        { SB.Append($"({KVP.Key.Identifier()}: {Nodes[KVP.Key]}), "); }

        return SB.ToString();
    }

    #endregion
}


[JsonSerializable(typeof(ElevationNode))]
public class ElevationNode : NavNode, ISpecialNode
{
    #region Member Variables
    [JsonInclude]
    [JsonPropertyName("IntNm")]
    public override string InternalName { get; set; } = "Default Elevation";

    [JsonInclude]
    public override Dictionary<NodeDirection, int> Nodes { get; internal set; } = new Dictionary<NodeDirection, int>();

    /// <summary>
    /// Specifies whether this node is an elevator (<c>true</c>) or stairs (<c>false</c>)
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("IsEN")]
    public bool IsElevator { get; set; }

    /// <summary>
    /// The Elevation group ID for this node
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("ENGID")]
    public int ENGroupID = 0;

    /// <summary>
    /// The number of nodes this is connected to
    /// </summary>
    [JsonIgnore]
    public override int ConnectedNodesCount
    {
        get { return Nodes.Count; }
    }
    #endregion

    #region Connections
    public override Dictionary<NodeDirection, int> GetConnectedNodes()
    {
        Dictionary<NodeDirection, int> Temp = new Dictionary<NodeDirection, int>();

        foreach (KeyValuePair<NodeDirection, int> N in Nodes)
        {
            if (Math.Abs(N.Value) > NavGraph.MINIMUM_UID)
            { Temp.Add(N.Key, N.Value); }
        }

        return Temp;
    }

    public Dictionary<NodeDirection, int> GetConnectedEN()
    {
        Dictionary<NodeDirection, int> Temp = new Dictionary<NodeDirection, int>();

        foreach (KeyValuePair<NodeDirection, int> N in Nodes)
        {
            if ((N.Key is (NodeDirection.Up or NodeDirection.Down))
                && Math.Abs(N.Value) > NavGraph.MINIMUM_UID)
            { Temp.Add(N.Key, N.Value); }
        }

        return Temp;
    }
    #endregion

    #region Other Overrides
    public override string ToString()
    {
        return base.ToString() + $", Up connection: {Nodes[NodeDirection.Up]}," +
            $" Down connection: {Nodes[NodeDirection.Down]}";
    }

    /// <summary>
    /// Checks if a node can connect on this direction (includes up/down)
    /// </summary>
    /// <param name="_Dir">Direction to check</param>
    /// <returns><see langword="true"/> if available, <see langword="false"/> otherwise</returns>
    public override bool IsAvailable(NodeDirection _Dir)
    {
        if (!Nodes.ContainsKey(_Dir))
        { return true; }

        return Math.Abs(Nodes[_Dir]) < NavGraph.MINIMUM_UID;
    }

    internal override void ConnectNode(int _UID, NodeDirection _Dir)
    {
        if (!Nodes.ContainsKey(_Dir))
        { Nodes.Add(_Dir, _UID); }
        else
        { Nodes[_Dir] = _UID; }
    }

    internal override void RemoveConnectedNode(NodeDirection _Dir)
    {
        if (Nodes.ContainsKey(_Dir))
        { Nodes.Remove(_Dir); }
    }
    #endregion
}


[JsonSerializable(typeof(GatewayNode))]
public class GatewayNode : NavNode, ISpecialNode
{
    #region Member Variables
    [JsonInclude]
    private Dictionary<NodeDirection, int> _Nodes = new Dictionary<NodeDirection, int>();

    [JsonIgnore]
    public override Dictionary<NodeDirection, int> Nodes
    {
        get => _Nodes;

        internal set
        {//Tries to ensure this only has 1 hard connection
            if (_Nodes.Count >= 1)
            { _Nodes.Clear(); }

            KeyValuePair<NodeDirection, int> Temp = value.First();

            _Nodes.Add(Temp.Key, Temp.Value);
        }
    }

    /// <summary>
    /// The number of Nodes this is connected to, this will return either 1 or 0
    /// </summary>
    [JsonIgnore]
    public override int ConnectedNodesCount
    { get => Nodes.Count; }

    [JsonIgnore]
    public int ConnectionsCount { get => Connections.Count(); }


    /// <summary>
    /// The GW connections of this node
    /// </summary>
    [JsonInclude]
    public Dictionary<string, List<int>> Connections = new();
    //                           ^gateway UIDs
    //                  ^Block name
    #endregion

    #region Overrides
    /// <summary>
    /// Returns the 1 hard-connected non-gateway node
    /// </summary>
    /// <returns>A dictionary defining their direction and their UID</returns>
    public override Dictionary<NodeDirection, int> GetConnectedNodes()
    { return Nodes; }

    /// <summary>
    /// Gets connected Gateway nodes
    /// </summary>
    /// <returns>A dictionary of Gateway UIDs and the name of their block</returns>
    public Dictionary<string, List<int>> GetConnectedGateways()
    { return Connections; }

    public override string ToString()
    {
        StringBuilder SB = new StringBuilder();

        foreach (var CN in Connections)
        { SB.Append($"Block: {CN.Key}, UID: {CN.Value}\n"); }

        return SB.ToString();
    }

    /// <summary>
    /// Checks if it's possible to connect to this node on a specific direction
    /// </summary>
    /// <returns>False, unless cosmic bit flip or some shit</returns>
    public override bool IsAvailable(NodeDirection _Direction)
    { return false; }

    public new bool IsConnected(int _UID)
    {
        if (Nodes.ContainsValue(_UID) || Connections.Values.Any(X => X.Contains(_UID)))
        { return true; }
        else
        { return false; }
    }

    /// <summary>
    /// Checks if this GW connects to a specific block
    /// </summary>
    /// <param name="_Block">Name of block</param>
    /// <returns>True if it is connected, false otherwise</returns>
    public bool IsConnected(string _Block)
    { return Connections.ContainsKey(_Block); }

    internal override void ConnectNode(int _NodeUID, NodeDirection _Direction)
    {
        if (_Direction != NodeDirection.Up && _Direction != NodeDirection.Down)
        { Nodes[_Direction] = _NodeUID; }
    }

    internal void ConnectNode(int _NodeUID, string _BlockName)
    {
        if (Connections.ContainsKey(_BlockName))
        {
            if (Connections[_BlockName] == null)
            { Connections[_BlockName] = new List<int>() { _NodeUID }; }
            else
            { Connections[_BlockName].Add(_NodeUID); }
        }
        else
        { Connections.Add(_BlockName, new List<int>() { _NodeUID }); }
    }

    internal void RemoveConnectedNode(int _NodeUID)
    {
        foreach (var KVP in Connections)
        {
            if (KVP.Value.Contains(_NodeUID))
            { KVP.Value.Remove(_NodeUID); return; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_Block"></param>
    /// <returns></returns>
    public IEnumerable<int> AvailableNodes(string _Block)
        => Connections[_Block];

    #endregion
}
#endregion

//Thanks to @Guru Stron https://stackoverflow.com/a/74694760/19306828
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum NodeDirection
{
    [EnumMember(Value = "1")]
    North = 1,
    [EnumMember(Value = "2")]
    East = 2,
    [EnumMember(Value = "-1")]
    South = -1,
    [EnumMember(Value = "-2")]
    West = -2,
    [EnumMember(Value = "3")]
    Up = 3,
    [EnumMember(Value = "-3")]
    Down = -3,
}

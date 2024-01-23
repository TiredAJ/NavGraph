// Ignore Spelling: Nav UID Elv

using NavGraphTools.Src.Utilities;
using System.Text;
using System.Text.Json.Serialization;

namespace NavGraphTools;

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
    public virtual Dictionary<NodeDirection, int> Nodes { get; internal set; } = new Dictionary<NodeDirection, int>();
    #endregion

    #region Altering Connections
    internal virtual void ConnectNode(int _UID, NodeDirection _Dir)
    {
        if (_Dir == NodeDirection.Up || _Dir == NodeDirection.Down || _UID == 0)
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
        if (!(_Dir == NodeDirection.Up || _Dir == NodeDirection.Down)
            && !Nodes.ContainsKey(_Dir))
        { return true; }

        return Math.Abs(Nodes[_Dir]) > NavGraph.MINIMUM_UID;
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

public interface ISpecialNode
{ }

public interface IGatewayFlow
{
    [JsonInclude]
    public NodeDirection? GatewayFlowDirection { get; set; }
}

public interface IElevationFlow
{
    [JsonInclude]
    public NodeDirection? ElvFlowDirection { get; set; }
}
#endregion


#region Derived nodes
[JsonSerializable(typeof(CorridorNode))]
public class CorridorNode : NavNode, IGatewayFlow, IElevationFlow
{
    [JsonInclude]
    public override Dictionary<NodeDirection, int> Nodes { get; internal set; } = new Dictionary<NodeDirection, int>();

    [JsonInclude]
    public NodeDirection? ElvFlowDirection { get; set; }
    [JsonInclude]
    public NodeDirection? GatewayFlowDirection { get; set; }
}


[JsonSerializable(typeof(RoomNode))]
public class RoomNode : NavNode
{
    #region Member Variables
    public override string InternalName { get; set; } = "Default Room";
    public string RoomName { get; set; } = "Default Room Name";

    [JsonInclude]
    public override Dictionary<NodeDirection, int> Nodes { get; internal set; } = new Dictionary<NodeDirection, int>();

    [ListStringLength(50, true)]
    public List<string> Tags { get; set; } = new List<string>();
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
public class ElevationNode : NavNode, ISpecialNode, IGatewayFlow
{
    #region Member Variables
    public override string InternalName { get; set; } = "Default Elevation";

    [JsonInclude]
    public override Dictionary<NodeDirection, int> Nodes { get; internal set; } = new Dictionary<NodeDirection, int>();

    [JsonInclude]
    public NodeDirection? GatewayFlowDirection { get; set; }

    [JsonInclude]
    public bool IsElevator { get; set; }
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
    /// <param name="_Dir">Direction to check</param>
    /// <returns><see langword="true"/> if available, <see langword="false"/> otherwise</returns>
    public override bool IsAvailable(NodeDirection _Dir)
    {
        if (!Nodes.ContainsKey(_Dir))
        { return true; }

        return Math.Abs(Nodes[_Dir]) > NavGraph.MINIMUM_UID;
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
public class GatewayNode : NavNode, ISpecialNode, IElevationFlow
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
            if (_Nodes.Count == 1)
            {
                _Nodes.Clear();

                KeyValuePair<NodeDirection, int> Temp = value.First();

                _Nodes.Add(Temp.Key, Temp.Value);
            }
        }
    }

    [JsonInclude]
    public Dictionary<int, string> Connections = new Dictionary<int, string>();
    //                      ^Block name
    //                 ^gateway UID

    [JsonInclude]
    public NodeDirection? ElvFlowDirection { get; set; }
    #endregion

    #region Overrides
    /// <summary>
    /// Returns the 1 connected non-gateway node
    /// </summary>
    /// <returns>A dictionary defining their direction and their UID</returns>
    public override Dictionary<NodeDirection, int> GetConnectedNodes()
    { return Nodes; }

    /// <summary>
    /// Gets connected Gateway nodes
    /// </summary>
    /// <returns>A dictionary of Gateway UIDs and the name of their block</returns>
    public Dictionary<int, string> GetConnectedGateways()
    { return Connections; }

    public override string ToString()
    {
        StringBuilder SB = new StringBuilder();

        foreach (var CN in Connections)
        { SB.Append($"Block: {CN.Key}, UID: {CN.Value}\n"); }

        return SB.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>False, unless cosmic bit flip or some shit</returns>
    public override bool IsAvailable(NodeDirection _Direction)
    { return false; }

    public new bool IsConnected(int _UID)
    {
        if (Connections.ContainsKey(_UID) || Nodes.ContainsValue(_UID))
        { return true; }
        else
        { return false; }
    }

    internal override void ConnectNode(int _NodeUID, NodeDirection _Direction)
    {
        if (_Direction != NodeDirection.Up && _Direction != NodeDirection.Down)
        { Nodes[_Direction] = _NodeUID; }
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

#region Misc
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
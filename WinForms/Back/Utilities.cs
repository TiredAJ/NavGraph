using NavGraphTools;
using System.Text;

namespace WinForms.Tools;

public static class Extensions
{
    /// <summary>
    /// Takes a string and extracts the UID from it
    /// </summary>
    /// <returns>int extracted from input</returns>
    public static int SplitNodeID(this string? _In)
    {
        if (_In is null)
        { return 0; }

        if (_In.Length > 0 && _In[2] == ':')
        { return int.Parse(_In.Split([' ', ':'])[1]); }
        else if (_In.Contains(" - "))
        { return int.Parse(_In.Split(" - ")[1]); }
        else
        { return int.Parse(_In.Split([' ', ':'])[0]); }
    }

    public static NodeDirection? ToDirection(this object? _Obj)
    { return _Obj.ToString().ToDirection(); }

    public static NodeDirection? ToDirection(this string? _Str)
    {
        if (_Str == null)
        { return null; }

        switch (_Str.ToLower())
        {
            default:
            case "north":
            { return NodeDirection.North; }
            case "east":
            { return NodeDirection.East; }
            case "south":
            { return NodeDirection.South; }
            case "west":
            { return NodeDirection.West; }
            case "up":
            { return NodeDirection.Up; }
            case "down":
            { return NodeDirection.Down; }
        }
    }

    public static string ToStr(this NodeDirection? _ND)
    {
        switch (_ND)
        {
            case NodeDirection.North:
            return "North";
            case NodeDirection.East:
            return "East";
            case NodeDirection.South:
            return "South";
            case NodeDirection.West:
            return "West";
            case NodeDirection.Up:
            return "Up";
            case NodeDirection.Down:
            return "Down";
            default:
            return "N/A";
        }
    }

    public static string ElementString(this List<string> _LStr)
    {
        StringBuilder SB = new StringBuilder();

        foreach (var E in _LStr)
        { SB.Append($"{E}, "); }

        return SB.ToString();
    }

    public static string ToArrow(this NodeDirection? _ND)
    {
        switch (_ND)
        {
            case NodeDirection.North:
            { return "↑"; }
            case NodeDirection.East:
            { return "→"; }
            case NodeDirection.South:
            { return "↓"; }
            case NodeDirection.West:
            { return "←"; }
            case NodeDirection.Up:
            { return "▲"; }
            case NodeDirection.Down:
            { return "▼"; }
            default:
            { return "#"; }
        }
    }

    public static string ToArrow(this NodeDirection _ND)
    {
        switch (_ND)
        {
            case NodeDirection.North:
            { return "↑"; }
            case NodeDirection.East:
            { return "→"; }
            case NodeDirection.South:
            { return "↓"; }
            case NodeDirection.West:
            { return "←"; }
            case NodeDirection.Up:
            { return "▲"; }
            case NodeDirection.Down:
            { return "▼"; }
            default:
            { return "#"; }
        }
    }

    public static string ToArrow(this string _ND)
    {
        switch (_ND)
        {
            case "North":
            { return "↑"; }
            case "East":
            { return "→"; }
            case "South":
            { return "↓"; }
            case "West":
            { return "←"; }
            case "Up":
            { return "▲"; }
            case "Down":
            { return "▼"; }
            default:
            { return "#"; }
        }
    }

    public static string NodeTypeShort(this Type _Type)
    {
        switch (_Type.Name)
        {
            case "CorridorNode":
            { return "CN"; }
            case "RoomNode":
            { return "RN"; }
            case "ElevationNode":
            { return "EN"; }
            case "GatewayNode":
            { return "GN"; }
            case "NavNode":
            { return "NN"; }
            default:
            { return "Not a node"; }
        }
    }

    public static string NodeTypeLong(this Type _Type)
    {
        switch (_Type.Name)
        {
            case "CorridorNode":
            { return "Corridor"; }
            case "RoomNode":
            { return "Room"; }
            case "ElevationNode":
            { return "Elevation"; }
            case "GatewayNode":
            { return "Gateway"; }
            case "NavNode":
            { return "NavNode"; }
            default:
            { return "Not a node"; }
        }
    }

    public static string IDToName(this string _ID)
    {
        switch (_ID)
        {
            case "CN":
            { return "CorridorNode"; }
            case "RN":
            { return "RoomNode"; }
            case "EN":
            case "ES":
            case "EE":
            { return "ElevationNode"; }
            case "GN":
            { return "GatewayNode"; }
            case "NN":
            { return "NavNode"; }
            default:
            { return "Not a node"; }
        }

    }

    public static string unTagList(this List<string> _StrLst)
    {
        StringBuilder SB = new StringBuilder();

        foreach (var S in _StrLst)
        { SB.Append($"{S},"); }

        return SB.ToString();
    }

    public static List<string> TagList(this string _Str)
    {
        List<string> L = new();

        foreach (var S in _Str.Split(','))
        { L.Add(S.Trim()); }

        return L;
    }

    public static bool IsValidUID(this int _UID)
    {
        if (Math.Abs(_UID) <= NavGraph.MINIMUM_UID)
        { return false; }
        else
        { return true; }
    }

    public static void AddIfNotNull<T>(this HashSet<T> _I, T? Value)
    {
        if (Value is not null)
        { _I.Add(Value); }
    }
}

public class LayoutHelper
{
    private List<Func<string>> LayoutOrder = new();

    public static Dictionary<string, string> NodeIdentifiers = new()
    {{"CN", "CN"},{"RN", "RN"},{"EN0", "ES"},{"EN1", "EE"},{"GW", "GW"}};

    private StringBuilder SB = new();

    public char _Separator = '-';
    public string _Blockname, TypeStr, _Prefix;
    public int _Floor;
    public bool IsElevator = false;

    public LayoutHelper()
    {
        LayoutOrder.Add(Prefix);
        LayoutOrder.Add(BlockChar);
        LayoutOrder.Add(Separator);
        LayoutOrder.Add(Floor);
        LayoutOrder.Add(Separator);
        LayoutOrder.Add(NodeType);
        LayoutOrder.Add(Separator);
    }

    public void SetLayout(string _Layout)
    {
        var Bits = _Layout.Split('{', '}').Where(X => X != "");

        LayoutOrder.Clear();

        foreach (var S in Bits)
        {
            switch (S)
            {
                case "B":
                { LayoutOrder.Add(BlockName); break; }
                case "b":
                { LayoutOrder.Add(BlockChar); break; }
                case "-":
                { LayoutOrder.Add(Separator); break; }
                case "F":
                { LayoutOrder.Add(Floor); break; }
                case "I":
                { LayoutOrder.Add(NodeType); break; }
                case "P":
                { LayoutOrder.Add(Prefix); break; }
                default:
                { break; }
            }
        }
    }

    public string GetName(string _Type, bool _IsElv = false)
    {
        IsElevator = _IsElv;
        TypeStr = _Type;

        SB.Clear();
        RunLayout();
        return SB.ToString();
    }

    private void RunLayout()
    {
        foreach (var F in LayoutOrder)
        {
            SB.Append(F());
        }
    }

    private string BlockName()
    { return _Blockname; }

    private string BlockChar()
    { return _Blockname.First().ToString(); }

    private string Floor()
    { return _Floor.ToString(); }

    private string NodeType()
    { return NodeIdentifier(); }

    private string Separator()
    { return _Separator.ToString(); }

    private string Prefix()
    { return _Prefix; }

    private string NodeIdentifier()
    {
        switch (TypeStr)
        {
            case "Corridor":
            { return NodeIdentifiers["CN"]; }
            case "Room":
            { return NodeIdentifiers["RN"]; }
            case "Elevation":
            { return IsElevator ? NodeIdentifiers["EN1"] : NodeIdentifiers["EN0"]; }
            case "Gateway":
            { return NodeIdentifiers["GW"]; }
            default:
            { return "Not a node"; }
        }
    }
}

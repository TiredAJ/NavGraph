using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace NavGraphTools.Utilities;

public static class Extensions
{
    public static string Identifier(this NodeDirection _ND)
    {
        switch (_ND)
        {
            default:
            case NodeDirection.North:
            return "N";
            case NodeDirection.East:
            return "E";
            case NodeDirection.South:
            return "S";
            case NodeDirection.West:
            return "W";
            case NodeDirection.Up:
            return "U";
            case NodeDirection.Down:
            return "D";
        }
    }

    public static string TrimAndCase(this string _S)
    {
        _S = _S.Trim();

        return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(_S.ToLower());
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

    /// <summary>
    /// Gets the opposite of this direction
    /// </summary>
    /// <returns>A node direction facing the opposite of this direction</returns>
    public static NodeDirection Inverse(this NodeDirection _ND)
    { return (NodeDirection)((int)_ND * -1); }

    public static KeyValuePair<NodeDirection, int> First(this Dictionary<NodeDirection, int> _N, IEnumerable<int> _Exclusions)
    { return _N.First(X => !_Exclusions.Contains(X.Value)); }

    public static KeyValuePair<NodeDirection, int> First(this IEnumerable<KeyValuePair<NodeDirection, int>> _N, IEnumerable<int> _Exclusions)
    { return _N.First(X => !_Exclusions.Contains(X.Value)); }

    public static IEnumerable<KeyValuePair<NodeDirection, int>> Skip(this IEnumerable<KeyValuePair<NodeDirection, int>> _N, HashSet<int> _Exclusions, int _Index)
    { return _N.Skip(_Index).ExceptBy(_Exclusions, X => X.Value); }

    public static int NoUpDownCount(this Dictionary<NodeDirection, int> _N)
    { return _N.Where(X => X.Key is not (NodeDirection.Up or NodeDirection.Down)).Count(); }

    public static int NoUpDownCount(this NavNode _N)
    { return _N.GetConnectedNodes().Where(X => X.Key is not (NodeDirection.Up or NodeDirection.Down)).Count(); }

    public static IEnumerable<KeyValuePair<NodeDirection, int>> NoUpDownSkip(this IEnumerable<KeyValuePair<NodeDirection, int>> _N, int _Index)
    { return _N.Where(X => X.Key is not (NodeDirection.Up or NodeDirection.Down)).Skip(1); }

    public static KeyValuePair<NodeDirection, int> NoUpDownFirst(this IEnumerable<KeyValuePair<NodeDirection, int>> _N)
    { return _N.Where(X => X.Key is not (NodeDirection.Up or NodeDirection.Down)).First(); }

    public static int ExclusionCount(this NavNode _N, HashSet<int> _Exclusions)
    { return _N.GetConnectedNodes().ExceptBy(_Exclusions, X => X.Value).Count(); }

    public static int ExclusionCount(this IEnumerable<KeyValuePair<NodeDirection, int>> _N, HashSet<int> _Exclusions)
    { return _N.ExceptBy(_Exclusions, X => X.Value).Count(); }

    /// <summary>
    /// Finds common ISPs between two ISpecialFlow Nodes
    /// </summary>
    /// <param name="_ISF2">Node to intersect with</param>
    /// <returns>An collection of common UIDs</returns>
    public static IEnumerable<int> Intersect(this ISpecialFlow _ISF1, ISpecialFlow _ISF2)
    {
        if (_ISF1.Flow is null || _ISF2.Flow is null)
        { throw new("Either _ISF1 or _ISF2 is null!"); }

        List<int> I1 = new(), I2 = new();

        foreach (var D in _ISF1.Flow.Values)
        { I1.AddRange(D.Keys); }

        foreach (var D in _ISF2.Flow.Values)
        { I2.AddRange(D.Keys); }

        return I1.Intersect(I2);
    }
}


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

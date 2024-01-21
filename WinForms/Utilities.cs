﻿using NavGraphTools;
using System.Text;

namespace WinForms
{
    public static class Extensions
    {
        /// <summary>
        /// Takes a string and extracts the UID from it
        /// </summary>
        /// <returns>int extracted from input</returns>
        public static int SplitNodeID(this string _In/*, int Level*/)
        {
            if (_In.Length > 0 && _In[2] == ':')
            { return int.Parse(_In.Split(new[] { ' ', ':' })[1]); }
            else
            { return int.Parse(_In.Split(new[] { ' ', ':' })[0]); }

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
                { return ""; }
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
    }

    public class Layout
    {
        private List<Func<string>> LayoutOrder = new();

        private static Dictionary<string, string> NodeIdentifiers = new()
        {{"CN", "CN"},{"RN", "RN"},{"ES", "ES"},{"GW", "GW"}};

        private StringBuilder SB = new();

        public char _Separator = '-';
        public string _Blockname, _Type, _Prefix;
        public int _Floor;

        public Layout()
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
            var Bits = _Layout.Split('{', '}');

            foreach (var S in Bits)
            {
                LayoutOrder.Clear();

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

        public string GetName()
        {
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
        { return NodeIdentifier(_Type); }

        private string Separator()
        { return _Separator.ToString(); }

        private string Prefix()
        { return _Prefix; }

        private string NodeIdentifier(string _T)
        {
            switch (_T)
            {
                case "Corridor":
                { return NodeIdentifiers["CN"]; }
                case "Room":
                { return NodeIdentifiers["RN"]; }
                case "Elevation":
                { return NodeIdentifiers["ES"]; }
                case "Gateway":
                { return NodeIdentifiers["GW"]; }
                default:
                { return "Not a node"; }
            }
        }
    }
}

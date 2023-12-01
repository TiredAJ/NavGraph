using NavGraphTools;
using System.Text;

namespace WinForms
{
    public static class Extensions
    {
        /// <summary>
        /// Takes a string and extracts the UID from it
        /// </summary>
        /// <returns>int extracted from input</returns>
        public static int SplitNodeID(this string _In)
        { return int.Parse(_In.Split(new[] { ' ', ':' }).First()); }

        public static NodeDirection ToDirection(this string _Str)
        {
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
    }
}

using NavGraphTools;
using NavGraphTools.Navigation;

namespace NavigatorTester;

class Program
{
    private static string MapPath =
        "E:\\GitHub\\_Individual Project\\Notes\\AdminPanel\\Maps\\Johnstone2.ajson";
    private static ReadonlyNavGraph NG;
    private static Pather P;

    static void Main(string[] args)
    {
        //so we can use unicode arrows?
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        NG = new ReadonlyNavGraph();

        using (Stream s = new StreamReader(MapPath).BaseStream)
        { NG.Deserialise(s); }

        Console.WriteLine(NG.CountNodes());

        P = new Pather(ref NG, 49844, 49890);

        P.Start();

        //NavNode N = NG.TryGetNode(49890);
        //
        //var R = P.SlideUntil(X => X == null, N, true, 10000);

        //Console.WriteLine(R);
    }
}

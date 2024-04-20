using NavGraphTools;
using NavGraphTools.Utilities;

public static class Program
{
    private static ReadonlyNavGraph NG;
    private static Path_er PR;

    public static void Main(string[] args)
    {
        NG = new ReadonlyNavGraph();

        using (Stream S = new StreamReader("Johnstone6.apjson").BaseStream)
        { NG.Deserialise(S); }

        PR = new Path_er(ref NG);

        PR.Start(49875, 49879);
        //                         ^TRJ005
        //          ^TRJ001

    }
}
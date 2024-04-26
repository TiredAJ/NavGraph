using NavGraphTools;
using NavGraphTools.Utilities;

public static class Program
{
    private static ReadonlyNavGraph NG;
    private static Path_er PR;

    public static void Main(string[] args)
    {
        NG = new ReadonlyNavGraph();

        using (Stream S = new StreamReader("Johnstone-6-pp.ajson").BaseStream)
        { NG.Deserialise(S); }

        PR = new Path_er(ref NG);

        PR.Progress += PR_Progress;

        PR.Start(49875, 50057);
        //                         ^TRS-1-RN-031-c
        //          ^TRJ001

    }

    private static void PR_Progress(object? sender, PatherProgressEvent e)
    { Console.WriteLine($"Progress: {e.Current}"); }
}
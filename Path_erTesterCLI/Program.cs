using NavGraphTools;
using NavGraphTools.Utilities;

public static class Program
{
    private static ReadonlyNavGraph NG;
    private static Path_er PR;

    public static void Main(string[] args)
    {
        NG = new ReadonlyNavGraph();

        using (Stream S = new StreamReader("Johnstone7.ajson").BaseStream)
        { NG.Deserialise(S); }

        PR = new Path_er(ref NG);

        PR.Progress += PR_Progress;

        PR.Start(49997, 50054, Finish);
        //                              ^TRS032
        //              ^TRJ001

    }

    private static void PR_Progress(object? sender, PatherProgressEvent e)
    { Console.WriteLine($"Progress: {e.Current}"); }

    private static void Finish(List<(NodeDirection Dir, NavNode N)> _Path)
    {
        bool Start = true;
        string Name;

        Console.WriteLine("\n");

        foreach (var Step in _Path)
        {
            if (Step.N is RoomNode RN)
            { Name = RN.RoomName; }
            else
            { Name = Step.N.InternalName; }

            if (Start && Step.Dir == 0)
            { Console.WriteLine($"Starting at {Name}"); Start = false; }
            else if (Step.Dir == 0)
            { Console.WriteLine($"Head out towards {Step.N.BlockName} via {Name}"); }
            else
            { Console.WriteLine($"Go {Step.Dir,-6} to {Name}"); }
        }

        Console.WriteLine("You have arrived at your destination!");
    }
}
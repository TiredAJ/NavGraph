using NavGraphTools;
using NavGraphTools.Utilities;

public static class Program
{
    private static ReadonlyNavGraph NG;
    private static Path_er PR;

    public static void Main(string[] args)
    {
        int AUID, BUID;

        NG = new ReadonlyNavGraph();

        using (Stream S = new StreamReader("Johnstone7.ajson").BaseStream)
        { NG.Deserialise(S); }

        PR = new Path_er(ref NG);

        PR.Progress += PR_Progress;

        do
        {
            Console.Clear();
            Console.WriteLine("Please enter UID of starting node: ");

            int.TryParse(Console.ReadLine(), out AUID);

            Console.WriteLine("Please enter UID of destination node: ");

            int.TryParse(Console.ReadLine(), out BUID);

            if (!NG.IsValidUID(AUID) || !NG.IsValidUID(BUID))
            { Console.WriteLine("Invalid UIDs!"); }
            else
            { PR.Start(AUID, BUID, Finish); }
        } while (true);


        //PR.Start(50057, 49997, Finish);
        //              ^TRS031C         ^TRJ113 
        //PR.Start(49997, 50054, Finish);
        //              ^TRJ113         ^TRS032  
        //PR.Start(49984, 49981, Finish);
        //              ^TRJ128         ^TRJ133
        //PR.Start(49957, 50006, Finish);
        //              ^TRJ132         ^TRJ103

        //49875 TRJ001, 50057 TRS-1-RN-031-C

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
            { Console.WriteLine($"Head out towards {Step.N.BlockName} ({Name})"); }
            else
            { Console.WriteLine($"Go {Step.Dir,-6} to {Name}"); }
        }

        Console.WriteLine("You have arrived at your destination! Press any key to restart...");
        Console.ReadKey();

        Console.Clear();
    }
}
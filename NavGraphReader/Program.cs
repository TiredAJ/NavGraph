using NavGraphTools;

namespace NavGraphReader;

internal class Program
{
    static void Main(string[] args)
    {
        ReadonlyNavGraph NG = new ReadonlyNavGraph();

        string FileLoc = "E:\\GitHub\\_Individual Project\\NavGraph\\Path_erTesterCLI\\Johnstone8.ajson";
        string NewFileLoc = "E:\\GitHub\\_Individual Project\\NavGraph\\Path_erTesterCLI\\Rooms.txt";

        using (Stream S = new StreamReader(FileLoc).BaseStream)
        {
            if (S is null)
            { throw new System.Exception("S was null!"); }
            else if (NG is null)
            { throw new System.Exception("NG was null!"); }

            NG.Deserialise(S);
        }

        using (StreamWriter Writer = new StreamWriter(NewFileLoc))
        {
            foreach (var KVP in NG.GetAllNodes().Where(X => X.Value is RoomNode))
            { Writer.WriteLine($"{(KVP.Value as RoomNode).RoomName}: {KVP.Key}"); }
        }
    }
}

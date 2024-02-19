using NavGraphTools;

namespace AdminPanelCLI;

//**************************
//
//  Main
//
//**************************

public partial class Program
{
    NavGraph NG = new NavGraph();


    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    static void MainMenu()
    {
        bool Cycle = true;

        do
        {
            Console.Clear();
            Console.WriteLine("Main Menu \n\n");

            Console.WriteLine("Options:");
            Console.WriteLine("[P] - Import/Export");
            Console.WriteLine("[N] - Nodes");
            Console.WriteLine("[B] - Blocks");
            Console.WriteLine("[E] - Exit");

            switch (Console.ReadLine().First())
            {
                case 'P':
                case 'p':
                { break; }

                case 'N':
                case 'n':
                { break; }

                case 'B':
                case 'b':
                { break; }

                default:
                { break; }
            }

        } while (Cycle);

    }
}

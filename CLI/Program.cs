using NavGraphTools;
using System.Diagnostics;

namespace NavGraphTester
{
    public class Program
    {
        static NavGraph Map;
        static Navigator Nav;
        static void Main(string[] args)
        {
            NavNode TempNode;

            Map = new NavGraph(true);

            Nav = new Navigator();

            do
            {
                Console.Clear();

                if (Map.CountNodes() > 0)
                {Console.WriteLine($"Map currently contains {Map.CountNodes()} Nodes\n");}
                else
                {Console.WriteLine("Map currently contains no nodes\n");}

                Console.Write("What would you like to do?\n\t[0] Create Node");
                Console.Write("\n\t[1] Connect nodes\n\t[2] Connect Elevation Nodes\n\t[3] Remove node");
                Console.Write("\n\t[4] List nodes\n\t[5] List nodes & connections\n\t[6] Serialise Data");
                Console.Write("\n\t[7] Deserialise data\n");

                ConsoleKey Temp = DebugReadKey();

                switch (Temp)
                {
                    case ConsoleKey.D1:
                    {
                        ConnectNodes();
                        break;
                    }
                    case ConsoleKey.D2:
                    {
                        ConnectElevationNodes();
                        break; 
                    }
                    case ConsoleKey.D3:
                    {
                        RemoveNode();
                        break; 
                    }
                    case ConsoleKey.D4:
                    {
                        ListNodes(false);
                        break; 
                    }
                    case ConsoleKey.D5:
                    {
                        ListNodes(true);
                        break;
                    }
                    case ConsoleKey.D6:
                    {
                        Serialise();
                        break;
                    }
                    case ConsoleKey.D7:
                    {
                        Deserialise();
                        break;
                    }
                    case ConsoleKey.D0:
                    {
                        do
                        {
                            Console.WriteLine($"UID: {Map.AddNode(NewNode())}");

                            Console.WriteLine("\nWould you like to make another? [y]/[n] ");
                        } while (DebugReadKey() != ConsoleKey.N);
                        break; 
                    }
                    default:
                    {break;}
                }

            } while (true);
        }

        public static NavNode NewNode()
        {
            NavNode? Temp = null;
            bool RoomNode = true, AcceptableInput = false;
            ConsoleKey TempCK;

            do
            {
                Console.Clear();

                Console.Write("Is node a [R]oom node or an [E]levation node? ");

                TempCK = DebugReadKey();

                if (TempCK == ConsoleKey.R)
                {
                    Temp = new RoomNode();
                    RoomNode = true;
                    AcceptableInput = true;
                }
                else if (TempCK == ConsoleKey.E)
                {
                    Temp = new ElevationNode();
                    RoomNode = false;
                    AcceptableInput = true;
                }

            } while (!AcceptableInput);

            if (Temp == null)
            {throw new NullReferenceException("Temp was null!");}

            Console.Clear();

            if (RoomNode)
            {Console.WriteLine("Creating new room node...\n");}
            else
            {Console.WriteLine("Creating new elevation node...\n");}

            Console.Write("Block Prefix: ");
            Temp.BlockPrefix = Console.ReadLine();

            Console.Write("Block Name: ");
            Temp.BlockName = Console.ReadLine();

            Console.Write("Floor: ");
            Temp.Floor = Console.ReadLine();

            Console.Write("Internal Name: ");
            Temp.InternalName = Console.ReadLine();

            if (Temp is RoomNode TR)
            {
                Console.Write("Room Name: ");
                TR.RoomName = Console.ReadLine();
                return TR;
            }

            return Temp;
        }

        public static void ConnectNodes()
        {
            int RoomA, RoomB;
            bool IsOneWay = false, ValidInput = false;
            ConsoleKey Input;

            NodeDirection ND;

            var AllNodes = Map.GetAllNodes();

            do
            {
                Console.Clear();
                Console.WriteLine("Would you like to see available nodes? [y/n]");

                Input = DebugReadKey();

                Console.Clear();
                Console.WriteLine("Connecting Rooms\n");

                if (Input == ConsoleKey.Y)
                {
                    Console.WriteLine("Rooms:");

                    InternalListNodes<RoomNode>();

                    //foreach (var N in AllNodes)
                    //{Console.WriteLine($" UID: {N.Key}, Room: {((RoomNode)N.Value).InternalName}");}
                    Console.WriteLine();

                    ValidInput = true;
                }
                else if (Input == ConsoleKey.N)
                {ValidInput = true;}
                else
                {
                    Console.WriteLine("Key not recognised");
                    ValidInput = false;
                }

            } while (!ValidInput);

            Console.WriteLine("Please enter the UID of the first room: ");

            int.TryParse(Console.ReadLine(), out RoomA);

            Console.WriteLine("Please enter the UID of a room to connect: ");

            int.TryParse(Console.ReadLine(), out RoomB);

            Console.Write("Please chose a direction from the first room: [N/E/S/W] ");

            switch (DebugReadKey())
            {
                case ConsoleKey.N:
                {
                    ND = NodeDirection.North;
                    break;
                }
                case ConsoleKey.E:
                {
                    ND = NodeDirection.East;
                    break;
                }
                case ConsoleKey.S:
                {
                    ND = NodeDirection.South;
                    break;
                }
                default:
                case ConsoleKey.W:
                {
                    ND = NodeDirection.West;
                    break;
                }
            }

            Console.Write("\nIs connection 1-way? [y/n] ");

            Input = DebugReadKey();

            if (Input == ConsoleKey.Y)
            {IsOneWay = true;}
            else if (Input == ConsoleKey.N)
            {IsOneWay = false;}
            else
            {Console.WriteLine("Unrecognised key");}

            Map.ConnectNodes(RoomA, RoomB, ND,IsOneWay, false);
        }

        public static void ConnectElevationNodes()
        {
            int A, B;
            bool Up = false;

            var AllNodes = Map.GetAllNodes();

            Console.WriteLine("Would you like to see available nodes? [y/n]");

            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine("Rooms:");

                InternalListNodes<ElevationNode>();

                //foreach (var N in AllNodes.Where(S => S.Value is ElevationNode))
                //{ Console.WriteLine($"\tUID: {N.Key}, Room: {((ElevationNode)N.Value).InternalName}"); }
                Console.WriteLine();
            }
            else
            { Console.WriteLine("Key not recognised"); }

            Console.WriteLine("Please enter the UID of the first elevation node to connect: ");
            int.TryParse(Console.ReadLine(), out A);
            Console.WriteLine("Please enter the UID of the second elevation node to connect: ");
            int.TryParse(Console.ReadLine(), out B);

            Console.Write("Does B connect atop A? [Y/N] ");
            if(DebugReadKey() == ConsoleKey.Y)
            {Up = true;}
            else
            {Up = false;}

            Map.ConnectElevationNodes(A, B,Up);
        }

        public static void RemoveNode()
        {
            int UIDToRemove = 0;

            ConsoleKey CK;

            Console.Clear();

            Console.WriteLine("Removing Nodes\n");

            Console.Write("would you like to see available nodes to remove? [y/n] ");

            if (DebugReadKey() == ConsoleKey.Y)
            {
                Console.WriteLine("\nAvailable nodes...");

                InternalListNodes<NavNode>();
            }

            Console.Write("\nPlease enter the UID of the node to remove: ");

            int.TryParse(Console.ReadLine(), out UIDToRemove);

            Console.Write("Would you like to [R]emove or [P]op node?");

            CK = DebugReadKey();

            if (CK == ConsoleKey.R)
            {Map.RemoveNode(UIDToRemove);}
            else if (CK == ConsoleKey.P)
            {

            }


        }

        public static void ListNodes(bool IncludeConnectedNodes)
        {
            Console.Clear();

            Console.WriteLine("Current Node List:\n");

            foreach (var N in Map.GetAllNodes())
            {
                Console.WriteLine($"> {N.Key}\t[{N.Value.InternalName}]");
                if (IncludeConnectedNodes && N.Value.GetConnectedNodes().Count > 0)
                {
                    foreach (KeyValuePair<NodeDirection, int> iN in N.Value.GetConnectedNodes())
                    {Console.WriteLine($"\t\\ {iN.Key} -> {iN.Value}");}
                }
                else if (IncludeConnectedNodes)
                {Console.WriteLine("\t\\ No connected Nodes");}
            }

            Console.WriteLine("Press any key to return");
            Console.ReadKey();
        }

        private static void InternalListNodes<T>()
        {
            var Nodes = Map.GetAllNodes().Where(KVP => KVP.Value is T);

            foreach (var N in Nodes) 
            {Console.WriteLine($"\tUID: {N.Key}, Room: {((ElevationNode)N.Value).InternalName}");}
        }

        public static void Serialise()
        {
            string FileLoc = "../Data.txt";

            using (FileStream FS = new FileStream(FileLoc, FileMode.OpenOrCreate))
            {Map.Serialise(FS);}
        }

        public static void Deserialise()
        {
            string FileLoc = "../Data.txt";

            using (FileStream FS = new FileStream(FileLoc, FileMode.Open))
            {Map.Deserialise(FS);}
        }

        public static ConsoleKey DebugReadKey()
        {
            ConsoleKey Temp = Console.ReadKey().Key;

            Debug.WriteLine($"DEBUG::KeyRead = {Temp}");

            return Temp;
        }
    }
}
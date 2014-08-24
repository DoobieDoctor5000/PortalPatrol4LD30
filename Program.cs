using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // Must use this for IFormatter
using System.Runtime.Serialization.Formatters.Binary; // Must use this for BinaryFormatter
using System.IO; // Must use this for Stream

namespace PortalPatrol
{
    class Program
    {
        static public Player player = new Player();
        static Intro intro = new Intro();
        static Laboratory lab = new Laboratory();
        static void Main(string[] args)
        {
            InitializePlayer();
            StartGame();
            if (player.finishedIntro == true)
            {
                Laboratory();
            }
        }

        static void InitializePlayer()
        {
            if (File.Exists("Player.bin"))
            {
                try
                {
                    LoadPlayer();
                }
                catch (SerializationException)
                {
                    player.exists = false;
                }
            }
            else
            {
                player.exists = false;
            }
        }

        static void StartGame()
        {
            if (player.exists == false)
            {
                intro.Dialogue1();
                Console.WriteLine();
                player.name = Console.ReadLine();
                player.exists = true;
                SavePlayer();
                intro.Dialogue2();
                player.finishedIntro = true;
                SavePlayer();
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Welcome back, officer {0}!", player.name);
                Console.WriteLine("");
                Console.WriteLine("Would you like to start a new game?");
                String input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "yes":
                    case "y":
                        FalsifyPlayerTriggers();
                        SavePlayer();
                        StartGame();
                        break;
                    case "no":
                    case "n":
                        Console.Clear();
                        Console.WriteLine("Ok.  Onwards!.");
                        Console.ReadLine();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine(@"I'm sorry, but I don't know what you mean by:
""{0}"".
Press Enter to Continue.", input);
                        Console.ReadLine();
                        StartGame();
                        break;
                };
            }
        }

        static void SavePlayer()
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("Player.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, player);
            }
        }

        static void LoadPlayer()
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("Player.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                player = (Player)formatter.Deserialize(stream);
            }
        }

        static void FalsifyPlayerTriggers()
        {
            player.exists = false;
            player.finishedIntro = false;
        }

        static void Laboratory()
        {
            Console.Clear();
            lab.Dialogue1();
            String input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "right":
                case "go right":
                case "turn right":
                case "make a right turn":
                case "exit":
                case "leave":
                case "quit":
                    Console.Clear();
                    Console.WriteLine(@"
Deciding that inter-dimensional police work isn't for
you, you exit the station.  Maybe this is for the best.
They seemed barbaric, and a little neurotic anyways.
Whatever you decide to do, you are your own person now.
Good luck in everything that you do.  Goodbye!

Press Enter to exit the game...");
                    Console.ReadLine();
                    break;
                case "left":
                case "go left":
                case "turn left":
                case "make a left turn":
                case "lab":
                case "laboratory":
                case "go to lab":
                case "go to the lab":
                case "go to laboratory":
                case "go to the laboratory":
                    lab.Dialogue2();
                    break;
                case "search":
                case "look around":
                    Console.Clear();
                    Console.WriteLine(@"
All you see is a plain hallway and the sign mentioned
before.  You find it odd that there's no one but
yourself in this barren hallway.  To the far left,
there's a door with a sign that says ""LABORATORY""
posted above it.  To your immediate right is a door
leading outside of the station.");
                    Laboratory();
                    break;
                case "look":
                    Console.WriteLine(@"
There's really nothing to look at, other than the sign
mentioned before.");
                    Laboratory();
                    break;
                default:
                    DoesNotCompute(input);
                    Laboratory();
                    break;
            }
        }
        static void DoesNotCompute(string input)
        {
            Console.Clear();
            Console.WriteLine(@"
The programmer of this game didn't prepare anything for:
""{0}""

Sorry!

Press Enter to continue...", input);
            Console.ReadLine();
        }
    }
}

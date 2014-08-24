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
            if (player.exists == true && player.finishedIntro == false)
            {
                FalsifyPlayerTriggers();
            }
            StartGame(); 
            if (player.finishedIntro == true && player.enteredLab == false)
            {
                Laboratory();
            }
            if (player.enteredLab == true && player.blueClothesOn == false)
            {
                lab.Dialogue2();
                Laboratory2();
                Laboratory3();
            }
            if (player.blueClothesOn == true && player.blueShellUp == false)
            {
                if (player.startingAgain == true)
                {
                    lab.Dialogue4();
                    player.startingAgain = false;
                }
                Laboratory4();
            }
            if (player.blueShellUp == true)
            {
                if (player.startingAgain == true)
                {
                    lab.Dialogue5();
                    player.startingAgain = false;
                }
                Laboratory5();
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
                        player.startingAgain = true;
                        SavePlayer();
                        Console.Clear();
                        Console.WriteLine("Ok.  Onwards!.");
                        EnterToContinue();
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
            player.enteredLab = false;
            player.blueClothesOn = false;
            player.blueShellUp = false;
            SavePlayer();
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
                    FalsifyPlayerTriggers();
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
                    player.enteredLab = true;
                    SavePlayer();
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
                    EnterToContinue();
                    Laboratory();
                    break;
                case "look":
                    Console.WriteLine(@"
There's really nothing to look at, other than the sign
mentioned before.");
                    EnterToContinue();
                    Laboratory();
                    break;
                default:
                    DoesNotCompute(input);
                    Laboratory();
                    break;
            }
        }

        static void Laboratory2()
        {
            String input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "no":
                case "no.":
                case "nope":
                case "nope.":
                case "i have no questions":
                case "i have no questions.":
                case "i don't have any questions":
                case "i don't have any questions.":
                case "i do not have any questions":
                case "i do not have any questions.":
                case "no questions":
                case "no questions.":
                case "no questions here":
                case "no questions here.":
                case "no sir":
                case "no sir.":
                case "no sir!":
                case "i don't think so":
                case "i don't think so.":
                    lab.Dialogue3();
                    break;
                case "what is your name":
                case "what's your name":
                case "whats your name":
                case "what is your name?":
                case "what's your name?":
                case "whats your name?":
                case "your name":
                case "your name?":
                case "tell me your name":
                case "tell me your name.":
                case "please tell me your name":
                case "please tell me your name.":
                    Console.Clear();
                    Console.WriteLine(@"
""IT DOESN'T MATTER WHAT MY NAME IS!

Anything else I can help you with?""");
                    Laboratory2();
                    break;
                case "portal":
                case "what's up with the blue portal?":
                case "what's up with the blue portal":
                case "what is up with the blue portal?":
                case "what is up with the blue portal":
                case "what is that portal?":
                case "what is that portal":
                case "what is that blue portal?":
                case "what is that blue portal":
                case "blue portal":
                    Console.Clear();
                    Console.Write(@"
""That");
                    QuickTextColor(ConsoleColor.Blue);
                    Console.Write(@"portal is the gate to the dimension
that the evil Dr. Wilde escaped to.  It's your next
destination!

Any more questions?""");
                    Laboratory2();
                    
                    break;
                case "dr. wilde":
                case "dr. wilde?":
                case "where is dr. wilde?":
                case "where is dr. wilde":
                case "where is wilde?":
                case "where is wilde":
                case "where's dr. wilde?":
                case "where's dr. wilde":
                case "where's wilde?":
                case "where's wilde":
                    Console.Clear();
                    Console.Write(@"
""She escaped through that");
                    QuickTextColor(ConsoleColor.Blue);
                    Console.Write(@"portal a few hours ago.
You need to go get her!

Any more questions?");
                    Laboratory2();
                    break;
                #region Ask a question
                case "who am i supposed to find?":
                case "who am i chasing after?":
                case "who is dr. wilde?":
                case "who is wilde?":
                case "why am i chasing dr. wilde?":
                case "why am i after dr. wilde?":
                case "why am i chasing wilde?":
                case "why am i after wilde?":
                case "what did dr. wilde do?":
                case "what did wilde do?":
                case "who am i supposed to find":
                case "who am i chasing after":
                case "who is dr. wilde":
                case "who is wilde":
                case "why am i chasing dr. wilde":
                case "why am i after dr. wilde":
                case "why am i chasing wilde":
                case "why am i after wilde":
                case "what did dr. wilde do":
                case "what did wilde do":
                    Console.Clear();
                    Console.WriteLine(@"
All you need to know is that Dr. Wilde is evil
and is in possession of stolen property that could,
in the wrong hands, result in ramifications that we
simply cannot allow.  Everything else is classified!

Any more questions that I can answer for you?");
                    Laboratory2();
                    break;
                #endregion
                default:
                    DoesNotCompute(input);
                    Console.Clear();
                    Console.WriteLine(@"
""Do you have any more questions for me?""");
                    Laboratory2();
                    break;
                    
            }
        }

        static void Laboratory3()
        {
            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                #region Enter Blue Portal in Lab - DEATH
                case "enter portal":
                case "enter the portal":
                case "enter through the portal":
                case "enter through portal":
                case "enter through the blue portal":
                case "enter through blue portal":
                case "portal":
                case "blue portal":
                case "jump into portal":
                case "jump in portal":
                case "jump into the portal":
                case "jump in the portal":
                case "enter blue portal":
                case "enter the blue portal":
                case "jump into blue portal":
                case "jump in blue portal":
                case "jump into the blue portal":
                case "jump in the blue portal":
                case "go through portal":
                case "go into portal":
                case "go in portal":
                case "go through the portal":
                case "go into the portal":
                case "go in the portal":
                case "go through blue portal":
                case "go into blue portal":
                case "go in blue portal":
                case "go through the blue portal":
                case "go into the blue portal":
                case "go in the blue portal":
                case "dive into portal":
                case "dive in portal":
                case "dive into the portal":
                case "dive in the portal":
                case "dive into blue portal":
                case "dive in blue portal":
                case "dive into the blue portal":
                case "dive in the blue portal":
                case "dive through the portal":
                case "dive through the blue portal":
                case "dive through portal":
                case "dive through blue portal":
                case "traipse into portal":
                case "traipse in portal":
                case "traipse into the portal":
                case "traipse in the portal":
                case "traipse into blue portal":
                case "traipse into the blue portal":
                case "traipse in blue portal":
                case "traipse in the blue portal":
                case "traipse through the portal":
                case "traipse through the blue portal":
                case "traipse through portal":
                case "traipse through blue portal":
                case "dance into portal":
                case "dance in portal":
                case "dance into the portal":
                case "dance in the portal":
                case "dance into blue portal":
                case "dance in blue portal":
                case "dance into the blue portal":
                case "dance in the blue portal":
                case "dance through portal":
                case "dance through the portal":
                case "dance through blue portal":
                case "dance through the blue portal":
                case "walk into the blue portal":
                case "walk in the blue portal":
                case "walk through the blue portal":
                case "walk into the portal":
                case "walk in the portal":
                case "walk through the portal":
                case "walk into blue portal":
                case "walk in blue portal":
                case "walk through blue portal":
                case "walk into portal":
                case "walk in portal":
                case "walk through portal":
                case "roll into the blue portal":
                case "roll in the blue portal":
                case "roll through the blue portal":
                case "roll into blue portal":
                case "roll in blue portal":
                case "roll through blue portal":
                case "roll into the portal":
                case "roll in the portal":
                case "roll through the portal":
                case "roll into portal":
                case "roll in portal":
                case "roll through portal":
                    Console.Clear();
                    Console.Write(@"
As you enter the");
                    QuickTextColor(ConsoleColor.Blue);
                    Console.Write(@"portal, you can hear the scientist
start to scream, ""Wait!  Nooo....!"" as your molecules begin to
separate one by one.  You feel no pain, as you literally cease to
exist.  In that split-second, your existence is completely forgotten,
not only in your own dimension, but in every other dimension also.
As a matter of fact, you are not reading this right now.  This game
doesn't exist.  Your computer doesn't exist.  The room you are in
doesn't exist.  Good going!

Press Enter to exit the game.");
                    Console.ReadLine();
                    FalsifyPlayerTriggers();
                    break;
                #endregion
                #region Put on blue clothes - PROGRESS
                case "blue clothes":
                case "blue uniform":
                case "blue clothing":
                case "blue garb":
                case "blue suit":
                case "don blue clothes":
                case "don blue uniform":
                case "don blue clothing":
                case "don blue garb":
                case "don blue suit":
                case "put on blue clothes":
                case "put on blue uniform":
                case "put on blue clothing":
                case "put on blue garb":
                case "put on blue suit":
                case "wear blue clothes":
                case "wear blue uniform":
                case "wear blue clothing":
                case "wear blue garb":
                case "wear blue suit":

                case "the blue clothes":
                case "the blue uniform":
                case "the blue clothing":
                case "the blue garb":
                case "the blue suit":
                case "don the blue clothes":
                case "don the blue uniform":
                case "don the blue clothing":
                case "don the blue garb":
                case "don the blue suit":
                case "put on the blue clothes":
                case "put on the blue uniform":
                case "put on the blue clothing":
                case "put on the blue garb":
                case "put on the blue suit":
                case "wear the blue clothes":
                case "wear the blue uniform":
                case "wear the blue clothing":
                case "wear the blue garb":
                case "wear the blue suit":

                case "appropriate clothes":
                case "appropriate uniform":
                case "appropriate clothing":
                case "appropriate garb":
                case "appropriate suit":
                case "don appropriate clothes":
                case "don appropriate uniform":
                case "don appropriate clothing":
                case "don appropriate garb":
                case "don appropriate suit":
                case "put on appropriate clothes":
                case "put on appropriate uniform":
                case "put on appropriate clothing":
                case "put on appropriate garb":
                case "put on appropriate suit":
                case "wear appropriate clothes":
                case "wear appropriate uniform":
                case "wear appropriate clothing":
                case "wear appropriate garb":
                case "wear appropriate suit":

                case "the appropriate clothes":
                case "the appropriate uniform":
                case "the appropriate clothing":
                case "the appropriate garb":
                case "the appropriate suit":
                case "don the appropriate clothes":
                case "don the appropriate uniform":
                case "don the appropriate clothing":
                case "don the appropriate garb":
                case "don the appropriate suit":
                case "put on the appropriate clothes":
                case "put on the appropriate uniform":
                case "put on the appropriate clothing":
                case "put on the appropriate garb":
                case "put on the appropriate suit":
                case "wear the appropriate clothes":
                case "wear the appropriate uniform":
                case "wear the appropriate clothing":
                case "wear the appropriate garb":
                case "wear the appropriate suit":

                case "correct clothes":
                case "correct uniform":
                case "correct clothing":
                case "correct garb":
                case "correct suit":
                case "don correct clothes":
                case "don correct uniform":
                case "don correct clothing":
                case "don correct garb":
                case "don correct suit":
                case "put on correct clothes":
                case "put on correct uniform":
                case "put on correct clothing":
                case "put on correct garb":
                case "put on correct suit":
                case "wear correct clothes":
                case "wear correct uniform":
                case "wear correct clothing":
                case "wear correct garb":
                case "wear correct suit":

                case "the correct clothes":
                case "the correct uniform":
                case "the correct clothing":
                case "the correct garb":
                case "the correct suit":
                case "don the correct clothes":
                case "don the correct uniform":
                case "don the correct clothing":
                case "don the correct garb":
                case "don the correct suit":
                case "put on the correct clothes":
                case "put on the correct uniform":
                case "put on the correct clothing":
                case "put on the correct garb":
                case "put on the correct suit":
                case "wear the correct clothes":
                case "wear the correct uniform":
                case "wear the correct clothing":
                case "wear the correct garb":
                case "wear the correct suit":
                    player.blueClothesOn = true;
                    SavePlayer();
                    lab.Dialogue4();
                    break;
                #endregion
                #region Shell-Up - LOOP
                case "shell-up":
                case "shell":
                case "blue shell":
                case "use shell":
                case "use blue shell":
                case "encapsulate":
                case "encapsulate self":
                case "encapsulate in shell":
                case "encapsulate in blue shell":
                case "encapsulate self in shell":
                case "encapsulate self in blue shell":
                case "activate shell":
                case "activate blue shell":
                case "holographic shell":
                case "holographic blue shell":
                case "blue holographic shell":
                case "activate holographic shell":
                case "activate blue holographic shell":
                case "activate holographic blue shell":
                case "use holographic shell":
                case "use holographic blue shell":
                case "use blue holographic shell":
                case "it's morphin' time!":
                    Console.Clear();
                    Console.Write(@"
Scientist: ""Wait just a minute now!  You need to put on
your");
                    QuickTextColor(ConsoleColor.Blue);
                    Console.Write(@"uniform before you shell-up!""

What would you like to do?:");
                    Laboratory3();
                    break;

                #endregion
                #region Assault scientist - DEATH
                case "crane-kick scientist":
                case "crane kick scientist":
                case "cranekick scientist":
                case "crane-kick the scientist":
                case "crane kick the scientist":
                case "cranekick the scientist":
                case "hit scientist":
                case "smack scientist":
                case "punch scientist":
                case "kick scientist":
                case "grab scientist":
                case "kiss scientist":
                case "lick scientist":
                case "molest scientist":
                case "fart on scientist":
                case "poot on scientist":
                case "jump on scientist":
                case "jump-kick scientist":
                case "roundhouse-kick scientist":
                case "roundhouse kick scientist":
                case "round-house kick scientist":
                case "roundhouse scientist":
                case "upper-cut scientist":
                case "uppercut scientist":
                case "suplex scientist":
                case "power-bomb scientist":
                case "powerbomb scientist":
                case "perform a hurracanrana on scientist":
                case "hurracanrana scientist":
                case "knee-bash scientist":
                case "knee bash scientist":
                case "kneebash scientist":
                case "spit on scientist":
                case "throw a haymaker towards scientist":
                case "throw a haymaker at scientist":
                case "haymaker scientist":
                case "elbow-bash scientist":
                case "elbow bash scientist":
                case "elbowbash scientist":
                case "bash elbow on scientist":
                case "choke scientist":
                case "push scientist":
                case "throw scientist":
                case "assault scientist":
                case "attack scientist":

                case "assault the scientist":
                case "attack the scientist":
                case "hit the scientist":
                case "smack the scientist":
                case "punch the scientist":
                case "kick the scientist":
                case "grab the scientist":
                case "kiss the scientist":
                case "lick the scientist":
                case "molest the scientist":
                case "fart on the scientist":
                case "poot on the scientist":
                case "jump on the scientist":
                case "jump-kick the scientist":
                case "roundhouse-kick the scientist":
                case "roundhouse kick the scientist":
                case "round-house kick the scientist":
                case "roundhouse the scientist":
                case "upper-cut the scientist":
                case "uppercut the scientist":
                case "suplex the scientist":
                case "power-bomb the scientist":
                case "powerbomb the scientist":
                case "perform a hurracanrana on the scientist":
                case "hurracanrana the scientist":
                case "knee-bash the scientist":
                case "knee bash the scientist":
                case "kneebash the scientist":
                case "spit on the scientist":
                case "throw a haymaker towards the scientist":
                case "throw a haymaker at the scientist":
                case "haymaker the scientist":
                case "elbow-bash the scientist":
                case "elbow bash the scientist":
                case "elbowbash the scientist":
                case "bash elbow on the scientist":
                case "choke the scientist":
                case "push the scientist":
                case "throw the scientist":
                    Console.Clear();
                    Console.WriteLine(@"
The scientist dodges your assault.  Without saying a word,
he pulls out his molecular deconstructor zapper, aims it
at you and pulls the trigger.

Congratulations!  You're now a puddle on the floor of the
laboratory.  IT'S GAME OVER MAN!  GAME OVER!

Press Enter to exit the game.");
                    
                    Console.ReadLine();
                    FalsifyPlayerTriggers();
                    break;
                #endregion
                default:
                    DoesNotCompute(input);
                    lab.Dialogue3();
                    Laboratory3();
                    break;
            }
        }

        static void Laboratory4()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                #region Enter Blue Portal in Lab - DEATH
                case "enter portal":
                case "enter the portal":
                case "enter through the portal":
                case "enter through portal":
                case "enter through the blue portal":
                case "enter through blue portal":
                case "portal":
                case "blue portal":
                case "jump into portal":
                case "jump in portal":
                case "jump into the portal":
                case "jump in the portal":
                case "enter blue portal":
                case "enter the blue portal":
                case "jump into blue portal":
                case "jump in blue portal":
                case "jump into the blue portal":
                case "jump in the blue portal":
                case "go through portal":
                case "go into portal":
                case "go in portal":
                case "go through the portal":
                case "go into the portal":
                case "go in the portal":
                case "go through blue portal":
                case "go into blue portal":
                case "go in blue portal":
                case "go through the blue portal":
                case "go into the blue portal":
                case "go in the blue portal":
                case "dive into portal":
                case "dive in portal":
                case "dive into the portal":
                case "dive in the portal":
                case "dive into blue portal":
                case "dive in blue portal":
                case "dive into the blue portal":
                case "dive in the blue portal":
                case "dive through the portal":
                case "dive through the blue portal":
                case "dive through portal":
                case "dive through blue portal":
                case "traipse into portal":
                case "traipse in portal":
                case "traipse into the portal":
                case "traipse in the portal":
                case "traipse into blue portal":
                case "traipse into the blue portal":
                case "traipse in blue portal":
                case "traipse in the blue portal":
                case "traipse through the portal":
                case "traipse through the blue portal":
                case "traipse through portal":
                case "traipse through blue portal":
                case "dance into portal":
                case "dance in portal":
                case "dance into the portal":
                case "dance in the portal":
                case "dance into blue portal":
                case "dance in blue portal":
                case "dance into the blue portal":
                case "dance in the blue portal":
                case "dance through portal":
                case "dance through the portal":
                case "dance through blue portal":
                case "dance through the blue portal":
                case "walk into the blue portal":
                case "walk in the blue portal":
                case "walk through the blue portal":
                case "walk into the portal":
                case "walk in the portal":
                case "walk through the portal":
                case "walk into blue portal":
                case "walk in blue portal":
                case "walk through blue portal":
                case "walk into portal":
                case "walk in portal":
                case "walk through portal":
                case "roll into the blue portal":
                case "roll in the blue portal":
                case "roll through the blue portal":
                case "roll into blue portal":
                case "roll in blue portal":
                case "roll through blue portal":
                case "roll into the portal":
                case "roll in the portal":
                case "roll through the portal":
                case "roll into portal":
                case "roll in portal":
                case "roll through portal":
                    Console.Clear();
                    Console.Write(@"
As you enter the");
                    QuickTextColor(ConsoleColor.Blue);
                    Console.Write(@"portal, you can hear the scientist
start to scream, ""Wait!  Nooo....!"" as your molecules begin to
separate one by one.  You feel no pain, as you literally cease to
exist.  In that split-second, your existence is completely forgotten,
not only in your own dimension, but in every other dimension also.
As a matter of fact, you are not reading this right now.  This game
doesn't exist.  Your computer doesn't exist.  The room you are in
doesn't exist.  Good going!

Press Enter to exit the game.");
                    Console.ReadLine();
                    FalsifyPlayerTriggers();
                    break;
                    #endregion
                #region Assault scientist - DEATH
                case "crane-kick scientist":
                case "crane kick scientist":
                case "cranekick scientist":
                case "crane-kick the scientist":
                case "crane kick the scientist":
                case "cranekick the scientist":
                case "hit scientist":
                case "smack scientist":
                case "punch scientist":
                case "kick scientist":
                case "grab scientist":
                case "kiss scientist":
                case "lick scientist":
                case "molest scientist":
                case "fart on scientist":
                case "poot on scientist":
                case "jump on scientist":
                case "jump-kick scientist":
                case "roundhouse-kick scientist":
                case "roundhouse kick scientist":
                case "round-house kick scientist":
                case "roundhouse scientist":
                case "upper-cut scientist":
                case "uppercut scientist":
                case "suplex scientist":
                case "power-bomb scientist":
                case "powerbomb scientist":
                case "perform a hurracanrana on scientist":
                case "hurracanrana scientist":
                case "knee-bash scientist":
                case "knee bash scientist":
                case "kneebash scientist":
                case "spit on scientist":
                case "throw a haymaker towards scientist":
                case "throw a haymaker at scientist":
                case "haymaker scientist":
                case "elbow-bash scientist":
                case "elbow bash scientist":
                case "elbowbash scientist":
                case "bash elbow on scientist":
                case "choke scientist":
                case "push scientist":
                case "throw scientist":
                case "assault scientist":
                case "attack scientist":

                case "assault the scientist":
                case "attack the scientist":
                case "hit the scientist":
                case "smack the scientist":
                case "punch the scientist":
                case "kick the scientist":
                case "grab the scientist":
                case "kiss the scientist":
                case "lick the scientist":
                case "molest the scientist":
                case "fart on the scientist":
                case "poot on the scientist":
                case "jump on the scientist":
                case "jump-kick the scientist":
                case "roundhouse-kick the scientist":
                case "roundhouse kick the scientist":
                case "round-house kick the scientist":
                case "roundhouse the scientist":
                case "upper-cut the scientist":
                case "uppercut the scientist":
                case "suplex the scientist":
                case "power-bomb the scientist":
                case "powerbomb the scientist":
                case "perform a hurracanrana on the scientist":
                case "hurracanrana the scientist":
                case "knee-bash the scientist":
                case "knee bash the scientist":
                case "kneebash the scientist":
                case "spit on the scientist":
                case "throw a haymaker towards the scientist":
                case "throw a haymaker at the scientist":
                case "haymaker the scientist":
                case "elbow-bash the scientist":
                case "elbow bash the scientist":
                case "elbowbash the scientist":
                case "bash elbow on the scientist":
                case "choke the scientist":
                case "push the scientist":
                case "throw the scientist":
                    Console.Clear();
                    Console.WriteLine(@"
The scientist dodges your assault.  Without saying a word,
he pulls out his molecular deconstructor zapper, aims it
at you and pulls the trigger.

Congratulations!  You're now a puddle on the floor of the
laboratory.  IT'S GAME OVER MAN!  GAME OVER!");
                    EnterToContinue();
                    FalsifyPlayerTriggers();
                    break;
                #endregion
                #region Shell-Up - PROGRESS
                case "shell-up":
                case "shell":
                case "blue shell":
                case "use shell":
                case "use blue shell":
                case "encapsulate":
                case "encapsulate self":
                case "encapsulate in shell":
                case "encapsulate in blue shell":
                case "encapsulate self in shell":
                case "encapsulate self in blue shell":
                case "activate shell":
                case "activate blue shell":
                case "holographic shell":
                case "holographic blue shell":
                case "blue holographic shell":
                case "activate holographic shell":
                case "activate blue holographic shell":
                case "activate holographic blue shell":
                case "use holographic shell":
                case "use holographic blue shell":
                case "use blue holographic shell":
                case "it's morphin' time!":
                    lab.Dialogue5();
                    player.blueShellUp = true;
                    SavePlayer();
                    break;

                #endregion
                default:
                    DoesNotCompute(input);
                    lab.Dialogue4();
                    Laboratory4();
                    break;
            }
        }

        static void Laboratory5()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                #region Assault scientist - DEATH
                case "crane-kick scientist":
                case "crane kick scientist":
                case "cranekick scientist":
                case "crane-kick the scientist":
                case "crane kick the scientist":
                case "cranekick the scientist":
                case "hit scientist":
                case "smack scientist":
                case "punch scientist":
                case "kick scientist":
                case "grab scientist":
                case "kiss scientist":
                case "lick scientist":
                case "molest scientist":
                case "fart on scientist":
                case "poot on scientist":
                case "jump on scientist":
                case "jump-kick scientist":
                case "roundhouse-kick scientist":
                case "roundhouse kick scientist":
                case "round-house kick scientist":
                case "roundhouse scientist":
                case "upper-cut scientist":
                case "uppercut scientist":
                case "suplex scientist":
                case "power-bomb scientist":
                case "powerbomb scientist":
                case "perform a hurracanrana on scientist":
                case "hurracanrana scientist":
                case "knee-bash scientist":
                case "knee bash scientist":
                case "kneebash scientist":
                case "spit on scientist":
                case "throw a haymaker towards scientist":
                case "throw a haymaker at scientist":
                case "haymaker scientist":
                case "elbow-bash scientist":
                case "elbow bash scientist":
                case "elbowbash scientist":
                case "bash elbow on scientist":
                case "choke scientist":
                case "push scientist":
                case "throw scientist":
                case "assault scientist":
                case "attack scientist":

                case "assault the scientist":
                case "attack the scientist":
                case "hit the scientist":
                case "smack the scientist":
                case "punch the scientist":
                case "kick the scientist":
                case "grab the scientist":
                case "kiss the scientist":
                case "lick the scientist":
                case "molest the scientist":
                case "fart on the scientist":
                case "poot on the scientist":
                case "jump on the scientist":
                case "jump-kick the scientist":
                case "roundhouse-kick the scientist":
                case "roundhouse kick the scientist":
                case "round-house kick the scientist":
                case "roundhouse the scientist":
                case "upper-cut the scientist":
                case "uppercut the scientist":
                case "suplex the scientist":
                case "power-bomb the scientist":
                case "powerbomb the scientist":
                case "perform a hurracanrana on the scientist":
                case "hurracanrana the scientist":
                case "knee-bash the scientist":
                case "knee bash the scientist":
                case "kneebash the scientist":
                case "spit on the scientist":
                case "throw a haymaker towards the scientist":
                case "throw a haymaker at the scientist":
                case "haymaker the scientist":
                case "elbow-bash the scientist":
                case "elbow bash the scientist":
                case "elbowbash the scientist":
                case "bash elbow on the scientist":
                case "choke the scientist":
                case "push the scientist":
                case "throw the scientist":
                    Console.Clear();
                    Console.WriteLine(@"
The scientist dodges your assault.  Without saying a word,
he pulls out his molecular deconstructor zapper, aims it
at you and pulls the trigger.

Congratulations!  You're now a puddle on the floor of the
laboratory.  IT'S GAME OVER MAN!  GAME OVER!");
                    EnterToContinue();
                    FalsifyPlayerTriggers();
                    break;
                #endregion
                #region Enter Blue Portal in Lab - PROGRESS
                case "enter portal":
                case "enter the portal":
                case "enter through the portal":
                case "enter through portal":
                case "enter through the blue portal":
                case "enter through blue portal":
                case "portal":
                case "blue portal":
                case "jump into portal":
                case "jump in portal":
                case "jump into the portal":
                case "jump in the portal":
                case "enter blue portal":
                case "enter the blue portal":
                case "jump into blue portal":
                case "jump in blue portal":
                case "jump into the blue portal":
                case "jump in the blue portal":
                case "go through portal":
                case "go into portal":
                case "go in portal":
                case "go through the portal":
                case "go into the portal":
                case "go in the portal":
                case "go through blue portal":
                case "go into blue portal":
                case "go in blue portal":
                case "go through the blue portal":
                case "go into the blue portal":
                case "go in the blue portal":
                case "dive into portal":
                case "dive in portal":
                case "dive into the portal":
                case "dive in the portal":
                case "dive into blue portal":
                case "dive in blue portal":
                case "dive into the blue portal":
                case "dive in the blue portal":
                case "dive through the portal":
                case "dive through the blue portal":
                case "dive through portal":
                case "dive through blue portal":
                case "traipse into portal":
                case "traipse in portal":
                case "traipse into the portal":
                case "traipse in the portal":
                case "traipse into blue portal":
                case "traipse into the blue portal":
                case "traipse in blue portal":
                case "traipse in the blue portal":
                case "traipse through the portal":
                case "traipse through the blue portal":
                case "traipse through portal":
                case "traipse through blue portal":
                case "dance into portal":
                case "dance in portal":
                case "dance into the portal":
                case "dance in the portal":
                case "dance into blue portal":
                case "dance in blue portal":
                case "dance into the blue portal":
                case "dance in the blue portal":
                case "dance through portal":
                case "dance through the portal":
                case "dance through blue portal":
                case "dance through the blue portal":
                case "walk into the blue portal":
                case "walk in the blue portal":
                case "walk through the blue portal":
                case "walk into the portal":
                case "walk in the portal":
                case "walk through the portal":
                case "walk into blue portal":
                case "walk in blue portal":
                case "walk through blue portal":
                case "walk into portal":
                case "walk in portal":
                case "walk through portal":
                case "roll into the blue portal":
                case "roll in the blue portal":
                case "roll through the blue portal":
                case "roll into blue portal":
                case "roll in blue portal":
                case "roll through blue portal":
                case "roll into the portal":
                case "roll in the portal":
                case "roll through the portal":
                case "roll into portal":
                case "roll in portal":
                case "roll through portal":
                    Console.Clear();
                    Console.Write(@"
Upon entering the");
                    QuickTextColor(ConsoleColor.Blue);
                    Console.Write(@"portal, you feel as though every
fiber in your being has been ripped apart and then
meticulously pieced back together, all in the matter of
a split-second.  You take one breath, and by the time
you are ready to exhale, the world around you has been
completely changed.
");
                    EnterToContinue();
                    Console.WriteLine(@"
Thank you very much for trying out my first Ludum Dare
entry!  I apologize for the game being unfinished.  In
hopes of allowing freedom of choice during gameplay,
development has taken much longer than I had originally
expected.  OK... honestly I didn't really expect to finish.
I learned a lot while making this game, and if anyone
actually likes what I've made so far, I just might
continue development on it.  But for now, I'll leave it
as-is for the 3-week voting period.  Please let me know
what you think of Portal Patrol so far, even if you think
it's pure-rubbish.  Until next time...");
                    EnterToContinue();
                    ConsoleTextColor(ConsoleColor.Blue);
                    Console.Write(@"
T");
                    ConsoleTextColor(ConsoleColor.Cyan);
                    Console.Write("o ");
                    ConsoleTextColor(ConsoleColor.Green);
                    Console.Write("B");
                    ConsoleTextColor(ConsoleColor.Yellow);
                    Console.Write("e ");
                    ConsoleTextColor(ConsoleColor.DarkYellow);
                    Console.Write("C");
                    ConsoleTextColor(ConsoleColor.Red);
                    Console.Write("o");
                    ConsoleTextColor(ConsoleColor.Blue);
                    Console.Write("n");
                    ConsoleTextColor(ConsoleColor.Cyan);
                    Console.Write("t");
                    ConsoleTextColor(ConsoleColor.Green);
                    Console.Write("i");
                    ConsoleTextColor(ConsoleColor.Yellow);
                    Console.Write("n");
                    ConsoleTextColor(ConsoleColor.DarkYellow);
                    Console.Write("u");
                    ConsoleTextColor(ConsoleColor.Red);
                    Console.Write("e");
                    ConsoleTextColor(ConsoleColor.Blue);
                    Console.Write("d");
                    ConsoleTextColor(ConsoleColor.Cyan);
                    Console.Write("!\n");
                    ConsoleTextColor(ConsoleColor.Green);
                    Console.Write("T");
                    ConsoleTextColor(ConsoleColor.Yellow);
                    Console.Write("h");
                    ConsoleTextColor(ConsoleColor.DarkYellow);
                    Console.Write("a");
                    ConsoleTextColor(ConsoleColor.Red);
                    Console.Write("n");
                    ConsoleTextColor(ConsoleColor.Blue);
                    Console.Write("k ");
                    ConsoleTextColor(ConsoleColor.Cyan);
                    Console.Write("y");
                    ConsoleTextColor(ConsoleColor.Green);
                    Console.Write("o");
                    ConsoleTextColor(ConsoleColor.Yellow);
                    Console.Write("u ");
                    ConsoleTextColor(ConsoleColor.DarkYellow);
                    Console.Write("L");
                    ConsoleTextColor(ConsoleColor.Red);
                    Console.Write("u");
                    ConsoleTextColor(ConsoleColor.Blue);
                    Console.Write("d");
                    ConsoleTextColor(ConsoleColor.Cyan);
                    Console.Write("u");
                    ConsoleTextColor(ConsoleColor.Green);
                    Console.Write("m ");
                    ConsoleTextColor(ConsoleColor.Yellow);
                    Console.Write("D");
                    ConsoleTextColor(ConsoleColor.DarkYellow);
                    Console.Write("a");
                    ConsoleTextColor(ConsoleColor.Red);
                    Console.Write("r");
                    ConsoleTextColor(ConsoleColor.Blue);
                    Console.Write("e ");
                    ConsoleTextColor(ConsoleColor.Cyan);
                    Console.Write("3");
                    ConsoleTextColor(ConsoleColor.Green);
                    Console.Write("0");
                    ConsoleTextColor(ConsoleColor.Yellow);
                    Console.Write("!\n");
                    ConsoleTextColor(ConsoleColor.DarkYellow);
                    Console.Write(":");
                    ConsoleTextColor(ConsoleColor.Red);
                    Console.Write(")\n");
                    Console.ResetColor();
                    Console.WriteLine(@"
Press Enter to exit the game");
                    Console.ReadLine();

                    break;
                default:
                    DoesNotCompute(input);
                    lab.Dialogue5();
                    Laboratory5();
                    break;
                #endregion
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

        static void ConsoleTextColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        static void QuickTextColor(ConsoleColor color)
        {
            ConsoleTextColor(color);
            switch (Console.ForegroundColor)
            {
                case ConsoleColor.Blue:
                    Console.Write(" Blue ");
                    break;
                case ConsoleColor.Cyan:
                    Console.Write(" Cyan ");
                    break;
                case ConsoleColor.Green:
                    Console.Write(" Green ");
                    break;
                case ConsoleColor.Yellow:
                    Console.Write(" Yellow ");
                    break;
                case ConsoleColor.DarkYellow:
                    Console.Write(" Dark Yellow ");
                    break;
                case ConsoleColor.Red:
                    Console.Write(" Red ");
                    break;
                default:
                    break;
            }
            Console.ResetColor();
        }

        static void EnterToContinue()
        {
            Console.WriteLine();
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalPatrol
{
    class Laboratory
    {
        public void Dialogue1()
        {
            Console.WriteLine(@"
You leave the captain's office and enter a hallway.
There's a sign on the wall that says ""LAB"" with an arrow
pointing left.  Just underneath, it says ""EXIT"" with an
arrow pointing right.

What would you like to do?:"); // Acquire input after this prompt.
        }

        public void Dialogue2()
        {
            Console.Clear();
            Console.WriteLine(@"
Insert next scene here.");
        }

        static void EnterToContinue()
        {
            Console.WriteLine();
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
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
    }
}

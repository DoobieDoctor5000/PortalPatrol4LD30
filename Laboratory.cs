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
            Console.Write(@"
You arrive at the laboratory to see one person in a lab coat.
There's a faint");
            QuickTextColor(ConsoleColor.Blue);
            Console.Write(@"portal in the middle of
the room.  It seems as though this scientist has been waiting
for you to arrive.  He approaches.

Scientist:""So, you're the new detective, huh?  Well, we're
kind of in a hurry right now, but do you have any questions
before I send you on your way?"""); // prompt for questions
            Console.WriteLine();
        }
        public void Dialogue3()
        {
            Console.Clear();
            Console.Write(@"
""OK then!  Let's get the show on the road! Go ahead and put
on your blue uniform, shell-up, and hop into this");
            QuickTextColor(ConsoleColor.Blue);
            Console.Write(@"portal
you see in the middle of the room.""

What will you do?"); // aquire input
            Console.WriteLine();
            //EnterToContinue();
        }

        public void Dialogue4()
        {
            Console.Clear();
            Console.Write(@"
The scientist doesn't seem to notice, or care,
while you disrobe and put the set of blue clothes
on.

What would you like to do now?
");
        }

        public void Dialogue5()
        {
            Console.Clear();
            Console.Write(@"
You activate your");
            QuickTextColor(ConsoleColor.Blue);
            Console.Write(@"encapsulation shell and the
scientist smiles.

Scientist: ""Looks like you know what you're doing.
OK well get on with it!  Enter the portal!""

What would you like to do?:
");
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

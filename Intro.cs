using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalPatrol
{
    class Intro
    {
        public void Dialogue1()
        {
            Console.Clear();
            Console.WriteLine(@"
""Welcome to the Inter-Dimensional Law Enforcement Agency, officer!
Please type your name into this here console to get started:"""); // take input for name after this.
        }

        public void Dialogue2()
        {
            Console.Clear();
            Console.WriteLine(@"
""Thank you officer {0}.  Again, welcome to IDLE.  You have joined
up with the premier and, well, ONLY Inter-Dimensional Law
Enforcement Agency in existence.  We pride ourselves on shelling-
out beat-downs on criminals across the universe and beyond!
Remember: You are above the law.  We will provide you with the
resources to provide punishment to whomever you deem
necessary.  But watch out: If you go too far and get caught on
camera doing it, it's a desk job for you!""", Program.player.name);
            EnterToContinue();
            Console.WriteLine(@"
""Now, before I set you loose upon civilization, we have to go over
a few things.  Here at IDLE, we make use of top-secret technology
called the Inter-Dimensional Transport Unit, or the ITU.  Some
call it IDU, others call it IDTU, but here at IDLE, it's ITU.  We
won't go over the specifics about how it works, but you have to
know the basics at least.""");
            EnterToContinue();
            Console.WriteLine(@"
""The ITU does what the name says it does: It transports you between
dimensions.  Given that there are an infinite number of dimensions,
we don't really have the capability to travel to each and every
one of them.  However, some scientist devised a way to identify
specific dimensions based off of the color spectrum.  She called it
""The Dimensional Spectrum"" or whatever, but all you need to know
is you pick a color and *FWOOOSH* you're there!""");
            EnterToContinue();
            Console.WriteLine(@"
""Ok... maybe it isn't so simple.  You see, when you travel from one
dimension to another, you have to BE the same color as the portal
you're using.  I don't know what'll happen if, say, you're flesh-
colored and you walk into a blue portal.  All I know is they say
bad things will happen if you do.  Given this, those sciency lab
rats have created a holographic shell that encapsulates us in the
color of our choice as we walk through the dimensional portals.
However, the shell isn't perfect, so we have to make up for its
shortcomings by wearing similar-colored clothing.  They don't have
to be the perfect color, but you don't want to be caught in red
clothing when traveling in a green shell.""");
            EnterToContinue();
            Console.WriteLine(@"
""Luckily, as per policy, you have six different-colored outfits
in your pack at all times.  This will allow you to traverse through
most of the portals available to us.  However, you want to stay
away from ultra-violet and infra-red portals.  Our uniforms aren't
yet optimized for such travel.""");
            EnterToContinue();
            Console.WriteLine(@"
""Whenever you jump a portal, you leave an anomaly in your wake on
both ends of the portal.  Ask a scientist if you want to know what
they are, but basically they need time to ""repair"" or whatever.
The stronger the anomaly, the fresher it is.  That brings us to our
next tool: The Anomalous.  The Anomalous is a nifty gadget that
detects the strength of all anomalies in the specific dimension that
you're in.  That means that if you're in a dimension with very strong
anomalies, chances are someone else has either recently jumped there
or at least jumped away from the dimension.""");
            EnterToContinue();
            Console.WriteLine(@"
""Why do we need the Anomalous?  Given your next assignment, which I
must admit is a doozy, it will be of great use to you.  You will be
pursuing a notorious inter-dimensional criminal who got ahold of one
of our ITU's.  The Anomalous will be your guide, letting you know
just how close you are to finding this menace.""");
            EnterToContinue();
            Console.Write(@"
""Oh yeah; there's one more thing I forgot to mention about the
Dimensional Spectrum.  The basic colors are");
            ConsoleTextColor(ConsoleColor.Blue);
            Console.Write(" Blue,");
            ConsoleTextColor(ConsoleColor.Cyan);
            Console.Write(" Cyan,");
            ConsoleTextColor(ConsoleColor.Green);
            Console.Write(" Green,\n");
            ConsoleTextColor(ConsoleColor.Yellow);
            Console.Write("Yellow,");
            ConsoleTextColor(ConsoleColor.DarkYellow);
            Console.Write(" Dark Yellow,");
            Console.ResetColor();
            Console.Write(" and");
            ConsoleTextColor(ConsoleColor.Red);
            Console.Write(" Red.");
            Console.ResetColor();
            Console.Write(@"  Don't ask me about Orange.
Everyone's always like ''Why is there no Orange? What is this Dark
Yellow crap?  Whine whine whine!''  Just accept that there are no
Orange portals!  Now we have that out of the way, I can tell you
this:  The");

            QuickTextColor(ConsoleColor.Green);
            Console.Write(@"portal will always bring you back here to this
dimension.  I don't want to see you back-tracking before finishing
your mission, but you should at least know which color brings you
back.  Given your dimensional footprint is of this dimension,");
            QuickTextColor(ConsoleColor.Green);

            Console.Write(@"
is your ticket back here, but people from other dimensions
use");

            QuickTextColor(ConsoleColor.Green);
            Console.Write(@"to get back to their own dimensions.  Confused yet?""");

            EnterToContinue();

            Console.WriteLine(@"
""ANYWAYS I'm tired of talking and I'm sure you're tired of hearing me talk.
Your mission is to find the nefarious Dr. Wilde and bring her to justice.
Which brand of justice you'd like to dole out is wholly up to you; just
don't bring any unwanted attention upon the department.  Now off you go to
the laboratory.  If I wasn't enough of a wind-bag for you, they will
surely give you any more information that you may need.""");

            EnterToContinue();
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

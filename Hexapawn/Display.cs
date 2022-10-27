using System;
using System.Collections.Generic;
using System.Text;

namespace Hexapawn
{
    public class Display
    {
        public static void MainMenu()
        {
            bool repeat = true;
            List<string> menu = new List<string>() { "Classic", "aaaah" };
            while (repeat)
            {
                int menuSelection = Menu(menu, "Main Menu");

                if (menuSelection == 0)
                    Console.WriteLine("1");
                else if (menuSelection == 1)
                    Console.WriteLine("2");
            }
        }
        public static int Menu(List<string> options, string subheading = "", string extra = "")
        {
            int position = 0;
            ConsoleKey consoleKey = ConsoleKey.Spacebar; //because it couldn't be null
            do
            {
                Console.Clear();
                Heading();
                SubHeading(subheading);
                Console.WriteLine(extra);
                for (int i = 0; i < options.Count; i++)
                {
                    if (i == position)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($" {options[i]}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"{options[i]}");
                    }
                }

                consoleKey = Console.ReadKey().Key;
                if (consoleKey == ConsoleKey.UpArrow)
                    position--;
                else if (consoleKey == ConsoleKey.DownArrow)
                    position++;
                position = ExtraMethods.EnforceLimits(position, 0, options.Count - 1, true);

                if (consoleKey == ConsoleKey.Escape)
                    position = Constants.Escape;

            } while (!(consoleKey == ConsoleKey.Enter) && !(consoleKey == ConsoleKey.Escape));

            return position;
        }
        private static void Heading()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t H E X A P A W N\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void SubHeading(string subHeading)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t    " + subHeading);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

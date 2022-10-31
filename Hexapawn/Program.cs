using System;
using System.Collections.Generic;
using Hexapawn.Assets;
using Hexapawn.Modes;

namespace Hexapawn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }
        public static void MainMenu()
        {
            bool repeat = true;
            List<string> menu = new List<string>() { "Classic", "aaaah" };
            while (repeat)
            {
                int menuSelection = Display.Menu(menu, "Main Menu");

                if (menuSelection == 0)
                {
                    GameState state = GameState.GetInstance();
                    IMode mode = new Classic(state);
                    mode.Run();
                }
                else if (menuSelection == 1)
                    Console.WriteLine("2");
            }
        }
    }
}

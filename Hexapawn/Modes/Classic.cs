using System;
using System.Collections.Generic;
using System.Text;
using Hexapawn.Assets;
using Hexapawn.Assets.Brains;

namespace Hexapawn.Modes
{
    public class Classic : IMode
    {
        private State state { get; set; }
        public Classic(State state)
        {
            this.state = state;
        }
        public void Run()
        {
            state.End = false;
            state.Turn = 1;
            state.Player1 = new Player(new User());
            state.Player2 = new Player(new Assets.Brains.Classic(), ConsoleColor.Black);
            while (!state.End)
            {
                if (state.Turn % 2 != 0)
                    state.Player1.Run();
                else
                    state.Player2.Run();

                Display.Board(state);
            }

            Console.WriteLine("\nPress 'Enter' to go back to the main menu");
            Console.ReadLine();
        }
    }
}

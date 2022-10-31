using System;
using System.Collections.Generic;
using System.Text;
using Hexapawn.Assets;
using Hexapawn.Assets.Brains;

namespace Hexapawn.Modes
{
    public class Classic : IMode
    {
        private GameState state { get; set; }
        public Classic(GameState state)
        {
            this.state = state;
        }
        public void Run()
        {
            state.Board = new Board();
           
            state.Player1 = new Player();
            state.Player1.Brain = new User(state.Player1);
            state.Player2 = new Player(ConsoleColor.Black.ToString());
            state.Player2.Brain = new Assets.Brains.Classic(state.Player2);

            state.SetBoard();
            state.End = false;
            state.Turn = 1;
            while (!state.End)
            {
                if (state.Turn % 2 != 0)
                    state.Player1.Run();
                else
                    state.Player2.Run();

                Display.Board();
            }

            Console.WriteLine("\nPress 'Enter' to go back to the main menu");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Hexapawn.Assets
{
    public class Player
    {
        public IBrain Brain { get; set; }
        public ConsoleColor Color { get; set; }

        public Player(IBrain brain, ConsoleColor color = ConsoleColor.White)
        {
            Brain = brain;
            Color = color;
        }
        public void Run()
        {
            Brain.Run();
        }
    }
}

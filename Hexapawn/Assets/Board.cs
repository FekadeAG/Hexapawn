using System;
using System.Collections.Generic;
using System.Text;

namespace Hexapawn.Assets
{
    public class Board
    {
        public string[,] Content { get; set; }
        public int Size { get; set; }
        public Board()
        {
            Size = 3;
        }
    }
}

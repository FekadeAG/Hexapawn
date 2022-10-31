using Hexapawn.Assets.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hexapawn.Assets
{
    public class Board
    {
        public Piece[,] Content { get; set; }
        public int Size { get; set; }
        public Board(int size = 3)
        {
            Size = size;
            Content = new Piece[Size, Size];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Hexapawn.Assets.Pieces;

namespace Hexapawn.Assets
{
    public class Piece
    {
        public string Color { get; set; }
        public int Number { get; set; }
        public PieceType Type { get; set; }
        public bool IsCaptured { get; set; }
        public override string ToString()
        {
            return $"{Color[0]}{Number}";
        }
    }
}

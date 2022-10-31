using System;
using System.Collections.Generic;
using System.Text;

namespace Hexapawn.Assets.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(string color, int number)
        {
            Color = color;
            Number = number;
            Type = PieceType.Pawn;
            IsCaptured = false;
        }
    }
}

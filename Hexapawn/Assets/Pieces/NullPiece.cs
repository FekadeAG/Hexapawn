using System;
using System.Collections.Generic;
using System.Text;

namespace Hexapawn.Assets.Pieces
{
    public class NullPiece : Piece
    {
        public NullPiece()
        {
            Type = PieceType.NullPiece;
        }
        public override string ToString()
        {
            return $"--";
        }
    }
}

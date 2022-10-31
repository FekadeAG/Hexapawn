using Hexapawn.Assets.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hexapawn.Assets
{
    public class Player
    {
        public IBrain Brain { get; set; }
        public string Color { get; set; }
        public List<Piece> MyPawns { get; set; }

        public Player(string color = "White")
        {
            Color = color;
            GenerateMyPawns();
        }
        public void Run()
        {
            Brain.Run();
        }
        private void GenerateMyPawns()
        {
            GameState state = GameState.GetInstance();
            MyPawns = new List<Piece>();
            for (int i = 1; i <= state.Board.Size; i++)
                MyPawns.Add(new Pawn(Color, i));
        }
    }
}

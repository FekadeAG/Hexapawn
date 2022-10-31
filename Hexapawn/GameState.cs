using System;
using System.Collections.Generic;
using System.Text;
using Hexapawn.Assets;
using Hexapawn.Assets.Pieces;

namespace Hexapawn
{
    public sealed class GameState
    {
        private static GameState _instance;
        private static readonly object _lock = new object();

        private GameState() { }

        public static GameState GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new GameState();
                }
            }
            return _instance;
        }

        public Board Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int Turn { get; set; }
        public bool End { get; set; }
        public List<string> MovesWhite { get; set; }
        public List<string> MovesBlack { get; set; }

        public void SetBoard()
        {
            for (int i = 0; i < Board.Size; i++)
            {
                Board.Content[i, 0] = Player1.MyPawns[i];
                for (int j = 1; j < Board.Content.GetLength(0) - 1; j++)
                    Board.Content[i, j] = new NullPiece();
                Board.Content[i, Board.Content.GetLength(1) - 1] = Player2.MyPawns[i];
            }
        }
        public List<string> GetAlMoves()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < MovesWhite.Count; i++)
            {
                list.Add(MovesWhite[i]);
                try { list.Add(MovesBlack[i]); } catch (ArgumentOutOfRangeException) { }
            }
            return list;
        }
        
    }
}

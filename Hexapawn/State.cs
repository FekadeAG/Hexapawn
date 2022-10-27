using System;
using System.Collections.Generic;
using System.Text;
using Hexapawn.Assets;

namespace Hexapawn
{
    public class State
    {
        public Board Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int Turn { get; set; }
        public bool End { get; set; }
        public List<string> MovesWhite { get; set; }
        public List<string> MovesBlack { get; set; }
        public List<string> MovesAll()
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

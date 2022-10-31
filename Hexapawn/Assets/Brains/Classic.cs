using System;
using System.Collections.Generic;
using System.Text;

namespace Hexapawn.Assets.Brains
{
    public class Classic : IBrain
    {
        private GameState gameState { get; set; }
        private Player player { get; set; }

        public Classic(Player player)
        {
            gameState = GameState.GetInstance();
            this.player = player;
        }
        public void Run()
        {

        }
    }
}

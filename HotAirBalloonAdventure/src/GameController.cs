using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace HotAirBalloonAdventure.src
{
    class GameController
    {
        private Player _player;
        public GameController()
        {
            Point2D playerLocation = new Point2D();
            playerLocation.X = 400;
            playerLocation.Y = 300;
            _player = new Player(playerLocation);
        }
        public void LoadResource()
        {
            _player.Draw();
            SwinGame.RefreshScreen();
        }
        public void ProcessMovement()
        {
            _player.Move();
        }
    }
}

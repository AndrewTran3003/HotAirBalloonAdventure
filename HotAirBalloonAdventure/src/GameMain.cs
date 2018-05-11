using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace HotAirBalloonAdventure.src
{
    class GameMain
    {
        static void Main()
        {
            SwinGame.OpenGraphicsWindow("HotAirBalloonAdventure", 1000, 600);
            GameController game1 = new GameController();
            game1.LoadResource();
            while (SwinGame.WindowCloseRequested() == false)
            {
                SwinGame.ProcessEvents();
                SwinGame.ClearScreen(Color.Black);
              

                game1.LoadResource();
                game1.ProcessMovement();
                SwinGame.RefreshScreen(60);

            }
        }
    }
}

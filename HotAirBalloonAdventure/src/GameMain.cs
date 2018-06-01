﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SwinGameSDK;

namespace HotAirBalloonAdventure.src
{
    class GameMain
    {
        static void Main()
        {
            SwinGame.OpenGraphicsWindow("HotAirBalloonAdventure", 1000, 600);
            GameController game1 = new GameController();
           

            while (SwinGame.WindowCloseRequested() == false)
            {


                
                game1.CreateBadThing();
                game1.CreateGoodThing();
                game1.HandleUserInput();
                game1.LoadResource();
                game1.ProcessMovement();
                game1.CheckCollision();
                game1.DeleteThing();
                if (game1.GameOver == true)
                {
                    break;
                }
                SwinGame.ProcessEvents();

                SwinGame.RefreshScreen(60);
     
             

            }
            game1.DisplayGameOver();
            Thread.Sleep(1000);
            game1.FreeResource();
        }
    }
}

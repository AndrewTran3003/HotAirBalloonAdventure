using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace HotAirBalloonAdventure.src
{
    class Bomb:BadThing
    {
        public Bomb(Point2D pt, int Score, int Size):base(pt,Score,Size)
        {

        }

        public override void Draw()
        {
            if(Size == 1)
            {
                SwinGame.LoadBitmapNamed("Bomb", "bomb.png");
                SwinGame.DrawBitmap("Bomb", LocationX, LocationY);
            }
            else
            {
                SwinGame.LoadBitmapNamed("Bomb2", "bomb2.jpg");
                SwinGame.DrawBitmap("Bomb2", LocationX, LocationY);
            }
        }
        public override void Move()
        {
            
        }
        public override void Interact(GameObject gb)
        {

        }
    }
}

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
            SwinGame.LoadBitmapNamed("Bomb", "bomb.png");
            SwinGame.DrawBitmap("Bomb", Location.X, Location.Y);
        }
        public override void Move()
        {
            
        }
        public override void Interact(GameObject gb)
        {

        }
    }
}

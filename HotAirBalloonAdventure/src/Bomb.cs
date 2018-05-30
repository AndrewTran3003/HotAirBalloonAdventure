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
        public Bomb(Point2D pt, int Score, float XSpeed):base(pt,Score,XSpeed)
        {

        }
        public override Bitmap ObjectBitmap()
        {
            return SwinGame.BitmapNamed("Bomb");
        }
        public override void Draw()
        {
            SwinGame.LoadBitmapNamed("Bomb", "bomb.png");
            SwinGame.DrawBitmap("Bomb", LocationX, LocationY);
           
        }
        public override void Move()
        {
            
        }
        public override void Interact(GameObject gb)
        {

        }
    }
}

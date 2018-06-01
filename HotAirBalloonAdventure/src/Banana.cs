using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace HotAirBalloonAdventure.src
{
    class Banana : GoodThing
    {
 
        private double _ySpeed;
        public Banana(Point2D pt, int Score, float XSpeed) : base(pt, Score,XSpeed)
        {
            Random Ran = new Random();
            _ySpeed = Ran.NextDouble();
        }
        public override Bitmap ObjectBitmap()
        {
            return SwinGame.BitmapNamed("Banana");
        }
        public override void Draw()
        {
            SwinGame.LoadBitmapNamed("Banana", "banana.png");
            SwinGame.DrawBitmap("Banana", LocationX, LocationY);
        }
        public override void Interact(GameObject gb)
        {
            if (IsAt(gb))
            {
                if (gb.GetType() == typeof(Apple))
                {
                    LocationX = gb.LocationY;
                    LocationY = gb.LocationX;
                }
            }
        }
        public override void Move()
        {
            LocationX += XSpeed;

            LocationY -= (float)_ySpeed;
        }

    }
}

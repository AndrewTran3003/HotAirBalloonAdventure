using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace HotAirBalloonAdventure.src
{
    class Star : GoodThing
    {
        float y;
        public Star(Point2D pt, int Score, float XSpeed) : base(pt, Score,XSpeed)
        {
            y = LocationY;
        }
        public override Bitmap ObjectBitmap()
        {
            return SwinGame.BitmapNamed("Star");
        }
        public override void Draw()
        {
            SwinGame.LoadBitmapNamed("Star", "star.png");
            SwinGame.DrawBitmap("Star", LocationX, LocationY);
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

            LocationY = (float)(100 * Math.Sin((Math.PI * LocationX) / 180) + 10) + y;
        }

    }
}

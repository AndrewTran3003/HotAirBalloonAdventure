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
        private float _yLocTemp;
        public Star(Point2D pt, float XSpeed) : base(pt,0,XSpeed)
        {
            _yLocTemp = LocationY;
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
                if (gb.GetType() == typeof(Dagger))
                {
                    gb.IsDestroyed = true;
                    IsDestroyed = true;
                }
            }
        }
        public override void Move()
        {
            LocationX += XSpeed;

            LocationY = (float)(100 * Math.Sin((Math.PI * LocationX) / 180) + 10) + _yLocTemp;
        }

    }
}

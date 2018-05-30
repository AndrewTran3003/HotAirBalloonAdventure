using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace HotAirBalloonAdventure.src
{
    class BlueBerry : GoodThing
    {

        int ax;
        double yx;
        public BlueBerry(Point2D pt, int Score,float XSpeed) : base(pt, Score,XSpeed)
        {
            Random Ran = new Random();
            yx = Ran.NextDouble();
        }
        public override Bitmap ObjectBitmap()
        {
            return SwinGame.BitmapNamed("BlueBerry");
        }
        public override void Draw()
        {
            SwinGame.LoadBitmapNamed("BlueBerry", "blueberry.png");
            SwinGame.DrawBitmap("BlueBerry", LocationX, LocationY);
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

            LocationY -= (float)yx;
        }

    }
}

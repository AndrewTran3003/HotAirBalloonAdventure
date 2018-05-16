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
        public BlueBerry(Point2D pt, int Score) : base(pt, Score)
        {
            Random Ran = new Random();
            ax = Ran.Next(1, 10);
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
            LocationX += ax;

            LocationY -= (float)yx;
        }

    }
}

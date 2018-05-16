using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace HotAirBalloonAdventure.src
{
    class Apple:GoodThing
    {
        public Apple(Point2D pt,int Score):base(pt,Score)
        {

        }
        public override Bitmap ObjectBitmap()
        {
            return SwinGame.BitmapNamed("Apple");
        }
        public override void Draw()
        {
            SwinGame.LoadBitmapNamed("Apple", "apple.png");
            SwinGame.DrawBitmap("Apple", LocationX, LocationY);
        }
        public override void Interact(GameObject gb)
        {
           if(IsAt(gb))
            {
                if (gb.GetType() == typeof(Apple))
                {
                    LocationX = gb.LocationY;
                    LocationY = gb.LocationX;
                }
            }
        }

    }
}

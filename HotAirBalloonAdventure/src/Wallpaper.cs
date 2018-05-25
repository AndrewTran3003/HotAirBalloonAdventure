using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
namespace HotAirBalloonAdventure.src
{
    class Wallpaper:GameObject
    {
        public Wallpaper(Point2D pt):base(pt,0)
        {

        }
        public override Bitmap ObjectBitmap()
        {
            return SwinGame.BitmapNamed("Wallpaper");
        }
        public override void Draw()
        {
            SwinGame.LoadBitmapNamed("Wallpaper", "wallpaper.png");
            SwinGame.DrawBitmap("Wallpaper", LocationX, LocationY);
        }
        public override void Move()
        {
            if (SwinGame.MouseX() >= 900 && LocationX - 1000 > -2560 && LocationX <= 0)
            {
                LocationX-=10;
            }

            if (SwinGame.MouseX() <= 100 && LocationX  > -2560 && LocationX < 0 )
            {
                LocationX+=10;
            }
            if(SwinGame.MouseY() >= 500 && LocationY - 600 > -1440 && LocationY - 600 < 0)
            {
                LocationY -= 10;
            }
            if (SwinGame.MouseY() <= 100 && LocationY < 0 && LocationY > -1440)
            {
                LocationY += 10;

            }

          

        }
    }
}

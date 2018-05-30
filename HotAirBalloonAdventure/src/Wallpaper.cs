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
            if (SwinGame.MouseX() >= 850 && SwinGame.CameraX() <= 1550)
            {
                SwinGame.MoveCameraTo(SwinGame.CameraX() + 10, SwinGame.CameraY());
            }

            if (SwinGame.MouseX() <= 150 && SwinGame.CameraX() >= 20)
            {
                SwinGame.MoveCameraTo(SwinGame.CameraX() - 10, SwinGame.CameraY());
            }
            if (SwinGame.MouseY() >= 450 && SwinGame.CameraY() <= 830)
            {
                SwinGame.MoveCameraTo(SwinGame.CameraX(), SwinGame.CameraY() + 10);
            }
            if (SwinGame.MouseY() <= 100 && SwinGame.CameraY() >= 20)
            {
                SwinGame.MoveCameraTo(SwinGame.CameraX(), SwinGame.CameraY() - 10);

            }



        }
    }
}

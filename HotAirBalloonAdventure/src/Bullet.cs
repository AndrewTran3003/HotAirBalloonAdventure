using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
namespace HotAirBalloonAdventure.src
{
    class Bullet:GameObject
    {
        public Bullet(Point2D pt):base(pt,0)
        {
           
        }

        public override Bitmap ObjectBitmap()
        {
            return SwinGame.BitmapNamed("Bullet");
        }
        public override void Draw()
        {
            SwinGame.LoadBitmapNamed("Bullet", "bullet.png");
            SwinGame.DrawBitmap("Bullet", LocationX, LocationY);
        }
        public override void Move()
        {
            LocationX = LocationX + 10;
        }
        public override void Interact(GameObject gb)
        {
            if (IsAt(gb))
            {
                if (gb.GetType() == typeof(Bomb))
                {
                    gb.IsDestroyed = true;
                    IsDestroyed = true;
                }
            }
           
        }
        
    }
}

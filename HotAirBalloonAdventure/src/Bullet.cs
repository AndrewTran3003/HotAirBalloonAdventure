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
        Player _player; 
        public Bullet(Point2D pt, Player p):base(pt,0)
        {
            _player = p;
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
                if (gb.GetType().BaseType == typeof(GoodThing))
                {
                    gb.IsDestroyed = true;
                    IsDestroyed = true;
                    if(_player.Score == 0)
                    {
                        if (_player.Shield == 0)
                        {
                            _player.LifePoint--;
                        }
                        else
                        {
                            _player.Shield--;
                        }
                    }
                    else
                    {
                        _player.Score -= gb.Score; 
                    }
                }

                if (gb.GetType().BaseType == typeof(BadThing))
                {
                    gb.IsDestroyed = true;
                    IsDestroyed = true;
                }

            }
           
        }
        
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
namespace HotAirBalloonAdventure.src
{
    class Bullet:GameObject
    {
        public Bullet(Point2D pt, int Score):base(pt,Score)
        {
           
        }

        public Bitmap BulletBitmap()
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
            if (IsAt(gb.Location))
            {
                if (gb.GetType() == typeof(Bomb))
                {
                    gb.IsDestroyed = true;
                    IsDestroyed = true;
                }
            }
           
        }
        public bool IsAt(Point2D pt)
        {
            return SwinGame.BitmapPointCollision(BulletBitmap(), LocationX, LocationY, pt);
        }
    }
}

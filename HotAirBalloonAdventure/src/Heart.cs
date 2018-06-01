using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace HotAirBalloonAdventure.src
{
    class Heart:GoodThing
    {
        private float _ySpeed;
        public Heart(Point2D pt, int Score, float XSpeed, float YSpeed) : base(pt, Score, XSpeed)
        {
            _ySpeed = YSpeed;
        }
        public override Bitmap ObjectBitmap()
        {
            return SwinGame.BitmapNamed("Heart");
        }
        public override void Draw()
        {
            SwinGame.LoadBitmapNamed("Heart", "heart.png");
            SwinGame.DrawBitmap("Heart", LocationX, LocationY);
        }
        public override void Interact(GameObject gb)
        {
            
        }
        public override void Move()
        {
            LocationX += XSpeed;
            LocationY -= _ySpeed;
            _ySpeed -= (float)0.009;
        }

    }
}

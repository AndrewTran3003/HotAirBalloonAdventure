using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SwinGameSDK;

namespace HotAirBalloonAdventure.src
{
    class Player:GameObject
    {
        private int _lifePoint;
        private int _shield;
        public Player(Point2D pt) : base(pt,0)
        {
            _lifePoint = 3;
            _shield = 0;
        }
        public Bitmap PlayerBitmap()
        {
            return SwinGame.BitmapNamed("Player");
        }
        public override void Draw()
        {
            
            SwinGame.LoadBitmapNamed("Player","hot-air-balloon.png");
            SwinGame.DrawBitmap("Player",Location.X,Location.Y);

        }
        public override void Move()
        {
            Location = SwinGame.MousePosition();
            Thread.Sleep(20);
        }
        public override void Interact()
        {
            
        }
        public  bool IsAt(Point2D pt)
        {
            return SwinGame.BitmapPointCollision(PlayerBitmap(), Location.X, Location.Y, pt);
        }
        public int LifePoint
        {
            get
            {
                return _lifePoint;
            }
            set
            {
                _lifePoint = value;
            }
        }
        public int Shield
        {
            get
            {
                return _shield;
            }
            set
            {
                _shield = value;
            }
        }

    }
}

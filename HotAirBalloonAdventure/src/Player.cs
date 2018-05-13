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
        private List<Bullet> _bullet;
        public Player(Point2D pt) : base(pt,0)
        {
            _lifePoint = 3;
            _shield = 0;
            _bullet = new List<Bullet>();
        }
        public override Bitmap ObjectBitmap()
        {
            return SwinGame.BitmapNamed("Player");
        }
        public override void Draw()
        {
            
            SwinGame.LoadBitmapNamed("Player","hot-air-balloon.png");
            SwinGame.DrawBitmap("Player",LocationX,LocationY);
            Font newFont = SwinGame.LoadFont("arial.ttf",80);
            SwinGame.DrawText(_lifePoint.ToString(), Color.White,newFont, LocationX+25, LocationY);

        }
        public override void Move()
        {
            LocationX = SwinGame.MouseX();
            LocationY = SwinGame.MouseY();
        }
        public override void Interact(GameObject gb)
        {
            
        }
        public  bool IsAt(Point2D pt)
        {
            return SwinGame.BitmapPointCollision(ObjectBitmap(), LocationX, LocationY, pt);
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
        public List<Bullet> Bullet
        {
            get
            {
                return _bullet;
            }
            set
            {
                _bullet = value;
            }
        }

    }
}

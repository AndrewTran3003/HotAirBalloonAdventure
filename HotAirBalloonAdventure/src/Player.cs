using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public override void Draw()
        {
            
            SwinGame.LoadBitmapNamed("Player","hot-air-balloon.png");
            SwinGame.DrawBitmap("Player",Location.X,Location.Y);

        }
        public override void Move()
        {
            Location = SwinGame.MousePosition();
        }
        public override void Interact()
        {
            
        }
        public override bool IsAt(Point2D pt)
        {
            return SwinGame.PointInRect(pt,Location.X,Location.Y,111,150);
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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
using System.Threading;

namespace HotAirBalloonAdventure.src
{
    abstract class BadThing : GameObject {
        private Player _player;
        private float _xSpeed;
        public BadThing(Point2D pt, int Score, float XSpeed, Player p):base(pt,Score)
        {
            _xSpeed = XSpeed;
            _player = p;
        }
        
       
     
        public override void Move()
        { 
            float a = _player.LocationX - LocationX;
            float b = _player.LocationY - LocationY;
            float Xspeed = a / (float)Math.Sqrt((float)Math.Pow(a,2) + (float)Math.Pow(b,2));
            float Yspeed = b / (float)Math.Sqrt((float)Math.Pow(a, 2) + (float)Math.Pow(b, 2));
            LocationX = LocationX + Xspeed;
            LocationY = LocationY + Yspeed;
          
        }
        public Player player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
            }
        }
      
    }
}

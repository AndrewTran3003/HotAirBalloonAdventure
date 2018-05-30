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

        private float _xSpeed;
        public BadThing(Point2D pt, int Score, float XSpeed):base(pt,Score)
        {
       
            _xSpeed = XSpeed;
        }
        
       
     
        public void Move(Player p)
        { 
            float a = p.LocationX - LocationX;
            float b = p.LocationY - LocationY;
            float Xspeed = a / (float)Math.Sqrt((float)Math.Pow(a,2) + (float)Math.Pow(b,2));
            float Yspeed = b / (float)Math.Sqrt((float)Math.Pow(a, 2) + (float)Math.Pow(b, 2));
            LocationX = LocationX + Xspeed;
            LocationY = LocationY + Yspeed;
          
        }
      
    }
}

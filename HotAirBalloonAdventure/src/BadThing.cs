using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
using System.Threading;

namespace HotAirBalloonAdventure.src
{
    abstract class BadThing:GameObject
    {
        private int _size;
        public BadThing(Point2D pt, int Score, int Size):base(pt,Score)
        {
            _size = Size;
        }
        
        public int SetSize
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }
     
        public void Move(Player p)
        {
            Point2D temp = new Point2D();
            float a = p.Location.X - Location.X;
            float b = p.Location.Y - Location.Y;
            float Xspeed = a / (float)Math.Sqrt((float)Math.Pow(a,2) + (float)Math.Pow(b,2));
            float Yspeed = b / (float)Math.Sqrt((float)Math.Pow(a, 2) + (float)Math.Pow(b, 2));
            temp.X = Location.X + Xspeed;
            temp.Y = Location.Y + Yspeed;
            Location = temp;
        }
      
    }
}

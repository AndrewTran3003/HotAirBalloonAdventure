using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace HotAirBalloonAdventure.src
{
    abstract class GoodThing:GameObject
    {
        public GoodThing(Point2D pt, int Score) : base(pt,Score)
        {
            
        }
        public override void Move()
        {
            
        }
        public abstract bool IsAt(Point2D pt);
    }
}

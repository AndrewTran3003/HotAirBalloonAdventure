using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using SwinGameSDK;
using Microsoft.Activities.Build;

namespace HotAirBalloonAdventure.src
{
   
        abstract class GoodThing : GameObject
        {
            float y;
            public GoodThing(Point2D pt, int Score) : base(pt, Score)
            {
            y = LocationY;
            }
            public override void Move()
            {
               LocationX += 5;
              
               LocationY = (float)(100 * Math.Sin((Math.PI*LocationX)/180) + 10) + y;
            }
            

    }
 }

    


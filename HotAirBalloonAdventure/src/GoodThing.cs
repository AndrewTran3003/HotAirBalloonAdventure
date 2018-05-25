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
        private float _xSpeed;
        public GoodThing(Point2D pt, int Score, float XSpeed) : base(pt, Score)
        {
            _xSpeed = XSpeed;
        }
        public float XSpeed
        {
            get
            {
                return _xSpeed;
            }
        }


    }
}




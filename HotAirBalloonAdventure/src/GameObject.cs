using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace HotAirBalloonAdventure.src
{
    abstract class GameObject
    {
        private Point2D _location;
        private int _score;
        public abstract void Draw();
        public abstract void Move();
        public abstract void Interact();
        public GameObject(Point2D pt, int Score)
        {
            _location = pt;
            _score = Score;
        }
        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }
        public Point2D Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
     

    }
}

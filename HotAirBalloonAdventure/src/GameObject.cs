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
        private bool _isDestroyed;
        public abstract void Draw();
        public abstract void Move();
        public virtual void Interact(GameObject gb)
        {

        }
        public abstract Bitmap ObjectBitmap();
        public GameObject(Point2D pt, int Score)
        {
            _location = pt;
            _score = Score;
            _isDestroyed = false;
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
        public float LocationX
        {
            get
            {
                return _location.X;
            }
            set
            {
                _location.X = value;
            }
        }
        public float LocationY
        {
            get
            {
                return _location.Y;
            }
            set
            {
                _location.Y = value;
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
        public bool IsDestroyed
        {
            get
            {
                return _isDestroyed;
            }
            set
            {
                _isDestroyed = value;
            }
        }
        public bool IsAt(GameObject gb)
        {
             return SwinGame.BitmapCollision(gb.ObjectBitmap(), gb.Location, ObjectBitmap(), Location);
        }


    }
}

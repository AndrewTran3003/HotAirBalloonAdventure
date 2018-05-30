using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace HotAirBalloonAdventure.src
{
    class GameController
    {
        private Player _player;
        private List<BadThing> _badThing;
        private List<GoodThing> _goodThing;
        private Wallpaper wallpaper;
        private GameBar gamebar;
        public GameController()
        {
            _badThing = new List<BadThing>();
            _goodThing = new List<GoodThing>();
            Point2D pt1 = new Point2D();
            Point2D pt2 = new Point2D();
            Point2D pt3 = new Point2D();
            pt1.X = 400;
            pt1.Y = 300;
            pt2.X = 0;
            pt2.Y = 0;
            pt3.X = 0;
            pt3.Y = 500;
            Player p1 = new Player(pt1);
            wallpaper = new Wallpaper(pt2);
            gamebar = new GameBar(pt3,p1);
            Player = p1;
          
        }
        public Player Player
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
        public void LoadResource()
        {
            wallpaper.Draw();
            foreach (BadThing bt in _badThing)
            {
                bt.Draw();
            }
            _player.Draw();
            if(_player.Bullet.Count > 0)
            {
                foreach (Bullet b in _player.Bullet)
                {
                    b.Draw();
                }
            }
           
            foreach (GoodThing gt in _goodThing)
            {
                gt.Draw();
            }
            gamebar.Draw();
            
        }
        public void ProcessMovement()
        {
            _player.Move();
            foreach(BadThing bt in _badThing)
            {
                bt.Move(_player);
            }

            if(_player.Bullet.Count > 0)
            {
                foreach (Bullet b in _player.Bullet)
                {
                    b.Draw();
                }
            }
            foreach (Bullet b in _player.Bullet)
            {
                b.Move();
            }
            foreach (GoodThing gt in _goodThing)
            {
                gt.Move();
            }
            wallpaper.Move();
            gamebar.Move();
        }
        public void DeleteThing()
        {
            List<BadThing> _newBadThing = new List<BadThing>();
            foreach (BadThing bt in _badThing)
            {
                if (bt.IsDestroyed == false)
                {
                    _newBadThing.Add(bt);
                }
            }

            List<Bullet> _newBullet = new List<Bullet>();
            foreach (Bullet b in _player.Bullet)
            {
                if (b.IsDestroyed == false && b.LocationX <= 2560)
                {
                    _newBullet.Add(b);
                }
                
            }

            List<GoodThing> _newGoodThing = new List<GoodThing>();
            foreach (GoodThing g in _goodThing)
            {
                if (g.IsDestroyed == false && g.LocationX <= 2560)
                {
                    _newGoodThing.Add(g);
                }

            }

            _badThing = _newBadThing;
            _player.Bullet = _newBullet;
            _goodThing = _newGoodThing;
           

        }
    
        public void CheckCollision()
        {
            foreach(Bullet b in _player.Bullet)
            {
                foreach (Bomb bomb in _badThing)
                {
                    b.Interact(bomb);
                }
            }
            foreach (GoodThing g in _goodThing)
            {
                _player.Interact(g);
            }
        }


        public void CreateBadThing()
        {
            if (_badThing.Count <= 1)
            {
                Random r = new Random();
                int x = r.Next(3, 7);
                int y;
                Random r2 = new Random();
                Point2D p1 = new Point2D();
                for (int i = 0; i < x; i++)
                {
                    y = r.Next(1, 5);
                    p1.X = r2.Next(-100, 2660);
                    p1.Y = r2.Next(-100, 0);
                    _badThing.Add(new Bomb(p1, -300, y));
                }
            }
            

        }
        public void CreateGoodThing()
        {
            if (_goodThing.Count <= 6)
            {
                Random r = new Random();
                int x = r.Next(3, 7);
                Random r2 = new Random();
                Point2D p1 = new Point2D();
                for (int i = 0; i < x; i++)
                {
                    p1.X = r2.Next(-100, -50);
                    p1.Y = r2.Next(100, 1440);
                    int y = r.Next(1,5);
                    if(y == 2)
                    {
                        _goodThing.Add(new Apple(p1, 300,r2.Next(2,5)));
                    }
                    else if(y==1)
                    {
                        _goodThing.Add(new Banana(p1, 300,r2.Next(2, 5)));
                    }
                    else if(y == 3)
                    {
                        _goodThing.Add(new Star(p1, r2.Next(2, 5)));
                    }
                    else
                    {
                        _goodThing.Add(new BlueBerry(p1, 300, r2.Next(2, 5)));
                    }
                    
                }
            }
        }
        public void HandleUserInput()
        {
            if (SwinGame.KeyTyped(KeyCode.SpaceKey))
            {
                 _player.Bullet.Add(new Bullet(Player.Location));
                _player.Score -= 30;
            }
        }

      
        public void FreeResource()
        {
            SwinGame.FreeBitmap(_player.ObjectBitmap());
            foreach(GoodThing gt in _goodThing)
            {
                SwinGame.FreeBitmap(gt.ObjectBitmap());
            }

            foreach (BadThing bt in _badThing)
            {
                SwinGame.FreeBitmap(bt.ObjectBitmap());
            }
            foreach(Bullet b in _player.Bullet)
            {
                SwinGame.FreeBitmap(b.ObjectBitmap());
            }
            SwinGame.FreeBitmap(wallpaper.ObjectBitmap());
        }
    }
}

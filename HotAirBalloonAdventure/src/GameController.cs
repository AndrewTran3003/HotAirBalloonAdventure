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
        private Wallpaper _wallpaper;
        private GameBar _gamebar;
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
            _wallpaper = new Wallpaper(pt2);
            _gamebar = new GameBar(pt3,p1);
            _player = p1;
          
        }
        
        public void LoadResource()
        {
            _wallpaper.Draw();
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
            _gamebar.Draw();
            
        }
        public void ProcessMovement()
        {
            _player.Move();
            foreach(BadThing bt in _badThing)
            {
                bt.Move();
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
            _wallpaper.Move();
            _gamebar.Move();
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
                foreach (BadThing bt in _badThing)
                {
                    b.Interact(bt);
                }
            }


            foreach (Bullet b in _player.Bullet)
            {
                foreach (GoodThing gt in _goodThing)
                {
                    b.Interact(gt);
                }
            }
            foreach (GoodThing gt in _goodThing)
            {
                _player.Interact(gt);
            }
            foreach (BadThing bt in _badThing)
            {
                _player.Interact(bt);
            }
            foreach (GoodThing gt in _goodThing)
            {
                foreach (BadThing bt in _badThing)
                {
                    bt.Interact(gt);
                }
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
                    int z = r.Next(1, 5);
                    y = r.Next(1, 5);
                    p1.X = r2.Next(-100, 2660);
                    p1.Y = r2.Next(-100, 0);
                    if(z == 1)
                    {
                        _badThing.Add(new Bomb(p1, y,_player));

                    }
                    else
                    {
                        _badThing.Add(new Dagger(p1, -300, y,_player));
                    }

                    
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
                    int y = r.Next(1,20);
                    if(y == 2)
                    {
                        _goodThing.Add(new Apple(p1, 100,r2.Next(2,5)));
                    }
                    else if( y == 1 )
                    {
                        _goodThing.Add(new Banana(p1, 300,r2.Next(2, 5)));
                    }
                    else if(y == 3)
                    {
                        _goodThing.Add(new Star(p1, r2.Next(2, 5)));
                    }
                    else if (y == 4)
                    {
                        _goodThing.Add(new Heart(p1, 0, r2.Next(2,5), r2.Next(2, 5)));
                        
                    }
                    else
                    {

                        _goodThing.Add(new BlueBerry(p1, 15, r2.Next(2, 5)));
                    }
                    
                }
            }
        }
        public void HandleUserInput()
        {
            if (SwinGame.KeyTyped(KeyCode.SpaceKey))
            {
                if(_player.Score >= 100)
                {
                    _player.Bullet.Add(new Bullet(_player.Location, _player));
                }
                
                
                
            }
        }
        public bool GameOver
        {
            get
            {
                if (_player.LifePoint == 0 || SwinGame.WindowCloseRequested() == true)
                {
                    return true;
                }
                return false;
            }
        }

        public void DisplayGameOver()
        {
            string displayText;
            SwinGame.ClearScreen(Color.Black);
            if (_player.LifePoint != 0)
            {
                displayText = "Game Over! Your score is: " + _player.Score;
                
            }
            else
            {
                displayText = "Game Over! You lose all your life point ";
            }
            SwinGame.DrawText(displayText, Color.White, 300 + SwinGame.CameraX(), 300 + SwinGame.CameraY());
            SwinGame.RefreshScreen();
            
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
            SwinGame.FreeBitmap(_wallpaper.ObjectBitmap());
        }
    }
}

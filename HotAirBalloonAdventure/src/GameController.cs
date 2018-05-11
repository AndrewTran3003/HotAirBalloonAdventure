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
        public GameController()
        {
            _badThing = new List<BadThing>();
            Point2D pt1 = new Point2D();
            pt1.X = 400;
            pt1.Y = 300;
            Player p1 = new Player(pt1);
            Player = p1;
            CreateBadThing();
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
            SwinGame.LoadBitmapNamed("Wallpaper", "wallpaper.png");
            SwinGame.DrawBitmap("Wallpaper",0,0);
            foreach (BadThing bt in _badThing)
            {
                bt.Draw();
            }
            _player.Draw();
            SwinGame.RefreshScreen();
        }
        public void ProcessMovement()
        {
            _player.Move();
            foreach(BadThing bt in _badThing)
            {
                bt.Move(_player);
            }
        }
        public void AddBadThing(BadThing bt)
        {
            _badThing.Add(bt);
        }
        public void RemoveBadThing(BadThing bt)
        {
            _badThing.Remove(bt);
        }

        public void CreateBadThing()
        {
            Random r = new Random();
            int x = r.Next(5, 10);
            for(int i = 0; i < 10; i++)
            {
                Random r2 = new Random();
                Point2D p1 = new Point2D();
                p1.X = r2.Next(1,800);
                p1.Y = r2.Next(1, 700);     
                _badThing.Add(new Bomb(p1, -300, 1));
            }

        }
    }
}

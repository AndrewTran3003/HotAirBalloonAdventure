﻿using System;
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
            foreach(Bullet b in _player.Bullet)
            {
                b.Draw();
            }
            SwinGame.RefreshScreen();
        }
        public void ProcessMovement()
        {
            _player.Move();
            foreach(BadThing bt in _badThing)
            {
                bt.Move(_player);
            }
            foreach (Bullet b in _player.Bullet)
            {
                b.Move();
            }
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
                if (b.IsDestroyed == false)
                {
                    _newBullet.Add(b);
                }
            }
            _badThing = _newBadThing;
            _player.Bullet = _newBullet;


        }
        public void AddBadThing(BadThing bt)
        {
            _badThing.Add(bt);
        }
        public void RemoveBadThing(BadThing bt)
        {
            _badThing.Remove(bt);
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
        }


        public void CreateBadThing()
        {
            Random r = new Random();
            int x = r.Next(3, 7);
            int y;
            Random r2 = new Random();
            Point2D p1 = new Point2D();
            for (int i = 0; i < x; i++)
            {
                y = r.Next(1, 5);
                p1.X = r2.Next(1,1100);
                p1.Y = r2.Next(1, 800);     
                _badThing.Add(new Bomb(p1, -300, y));
            }

        }
        public void HandleUserInput()
        {
            if (SwinGame.KeyTyped(KeyCode.SpaceKey))
            {
                _player.Bullet.Add(new Bullet(Player.Location,-30));
            }
        }
        public void FreeResource()
        {
            
        }
    }
}

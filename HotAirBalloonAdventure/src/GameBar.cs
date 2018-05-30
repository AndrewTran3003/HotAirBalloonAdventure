using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace HotAirBalloonAdventure.src
{
    class GameBar:GameObject
    {
        private Player _player;
        public GameBar(Point2D pt,Player p):base(pt,0)
        {
            _player = p;
        }
        public override Bitmap ObjectBitmap()
        {
            return SwinGame.BitmapNamed("GameBar");
        }
        public override void Draw()
        {
            SwinGame.LoadBitmapNamed("GameBar", "GameBar.png");
            SwinGame.DrawBitmap("GameBar", LocationX, LocationY);
            Font newFont = SwinGame.LoadFont("arial.ttf", 20);
            SwinGame.DrawText("Score: " +_player.Score.ToString(), Color.White, newFont, LocationX+20, LocationY+10);
            SwinGame.DrawText("Shield: " + _player.Shield.ToString(), Color.White, newFont, LocationX + 20, LocationY + 40);
            SwinGame.DrawText("Life Point: " + _player.LifePoint.ToString(), Color.White, newFont, LocationX + 20, LocationY + 70);
        }
        public override void Move()
        {
            LocationX = SwinGame.CameraX();
            LocationY = SwinGame.CameraY()+500;
        }
    }
}

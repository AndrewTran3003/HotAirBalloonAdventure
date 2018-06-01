using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace HotAirBalloonAdventure.src
{
    class Dagger : BadThing
    {
        public Dagger(Point2D pt, int Score, float XSpeed,Player p) : base(pt, Score, XSpeed,p)
        {
            player = p;
        }
        public override Bitmap ObjectBitmap()
        {
            return SwinGame.BitmapNamed("Dagger");
        }
        public override void Draw()
        {
            SwinGame.LoadBitmapNamed("Dagger", "dagger.png");
            SwinGame.DrawBitmap("Dagger", LocationX, LocationY);

        }
     
        public override void Interact(GameObject gb)
        {
            if (IsAt(gb))
            {
                if (gb.GetType() == typeof(Apple) || 
                    gb.GetType()== typeof(Banana)||
                    gb.GetType() == typeof(BlueBerry)||
                    gb.GetType() == typeof(Heart))
                {
                    gb.IsDestroyed = true;
                }


            }
        }
    }
}

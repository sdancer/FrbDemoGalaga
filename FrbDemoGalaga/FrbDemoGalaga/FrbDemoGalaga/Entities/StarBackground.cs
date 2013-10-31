using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;
using FrbDemoGalaga.Factories;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;


#endif

namespace FrbDemoGalaga.Entities
{
	public partial class StarBackground
	{
	    private const int SpawnStar = 400;
	    private const int SpawnStarY = 400;

	    private void CustomInitialize()
		{
            StarFactory.Initialize(StarList, ContentManagerName);

	        var y = SpawnStarY;

            while (y > -171)
            {
                if (GlobalRandom.Rand.Next(0, 1000) > SpawnStar)
                {
                    CreateStar(y);
                }
                y--;
            }
		}

        private void CreateStar(float newY)
        {
            var star = StarFactory.CreateNew();
            star.YVelocity = -80;
            star.Y = newY;
            star.X = GlobalRandom.Rand.Next(-125, 125);
            star.DestroyPoint = -171;
        }

		private void CustomActivity()
		{
            if (GlobalRandom.Rand.Next(0, 1000) > SpawnStar)
            {
                CreateStar(SpawnStarY);
            }
		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
	}
}

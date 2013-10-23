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
	public partial class Star
	{
	    private bool _running = true;
	    private bool _first = true;
	    private double _nextAction;

        private void RandomizeColor()
	    {
	    }

        private void NextAction()
        {
            if (_first)
            {
                _first = false;
                SpriteInstance.Visible = GlobalRandom.Rand.Next(0, 1) == 1;
            }
            else
            {
                SpriteInstance.Visible = !SpriteInstance.Visible;
            }

            _nextAction = TimeManager.CurrentTime + (SpriteInstance.Visible ? GlobalRandom.Rand.Next(500, 1500) / 1000f : .5f);
        }

		private void CustomInitialize()
		{
            SpriteInstance.Red = GlobalRandom.Rand.Next(0, 255) / 255f;
            SpriteInstance.Blue = GlobalRandom.Rand.Next(0, 255) / 255f;
            SpriteInstance.Green = GlobalRandom.Rand.Next(0, 255) / 255f;

		    _running = true;
		    _first = true;

            NextAction();
		}

		private void CustomActivity()
		{
            if (Y < DestroyPoint)
                Destroy();
            else
            {
                if(TimeManager.CurrentTime > _nextAction)
                    NextAction();
            }

		}

		private void CustomDestroy()
		{
		    _running = false;
		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Screens;

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

namespace FrbDemoGalaga.Entities.Ships
{
	public partial class PlayerShip
	{
        private float mFireCooldown;
        private double mLastShotFired; 

        /// <summary>
        /// Evaluates if mFireCooldown time has passed since the PlayerShip last fired. 
        /// </summary>
        private bool CanFire
        {
            get
            {
                return ScreenManager.CurrentScreen.PauseAdjustedSecondsSince(mLastShotFired) > mFireCooldown;
            }
        }

		private void CustomInitialize()
		{
            mFireCooldown = DefaultFireCooldown; 

		}

		private void CustomActivity()
		{
            PlayerInput();
            KeepWithinBoundaries();
		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        /// <summary>
        /// Registers player input and executes the appropriate operations. 
        /// </summary>
        private void PlayerInput()
        {
            //Change when input is abstracted abstracting input. 

            //Player Fires Input
            if (InputManager.Keyboard.KeyDown(Keys.Space))
                if (CanFire)
                    Fire(); 

            //Player Movement Input
            if (InputManager.Keyboard.KeyDown(Keys.A))
            {
                X = X - XSpeed * TimeManager.LastSecondDifference; 
            }
            else if (InputManager.Keyboard.KeyDown(Keys.D))
            {
                X = X + XSpeed * TimeManager.LastSecondDifference; 
            }
        }

        /// <summary>
        /// Moves the ship back within its boundaires if it has moved out of them. 
        /// </summary>
        private void KeepWithinBoundaries()
        {
            float minX = SpriteManager.Camera.AbsoluteLeftXEdgeAt(Z);
            float maxX = SpriteManager.Camera.AbsoluteRightXEdgeAt(Z);
            Visual.ForceUpdateDependencies(); 
            if (Visual.Right > maxX)
            {
                X = maxX - Visual.ScaleX; 
            }
            else if (Visual.Left < minX)
            {
                X = minX + Visual.ScaleX; 
            }
                
        }

        /// <summary>
        /// Fires a bullet from the players ship. 
        /// </summary>
        public override void Fire()
        {
            mLastShotFired = ScreenManager.CurrentScreen.PauseAdjustedCurrentTime;
            base.Fire();            
        }
	}
}

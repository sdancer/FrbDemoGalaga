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

namespace FrbDemoGalaga.Entities.Ships
{
	public partial class EnemyShip
	{
		private void CustomInitialize()
		{


		}

		private void CustomActivity()
		{


		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        /// <summary>
        /// Loads the Data for a particular enemy type. 
        /// </summary>
        /// <param name="enemyName"></param>
        public void LoadEnemyType(string enemyName)
        {
            if (!EnemyData.ContainsKey(enemyName))            
                throw new KeyNotFoundException("Key " + enemyName + " not found.");

            CurrentEnemyData = EnemyData[enemyName];

            Visual.AnimationChains.Clear();
            AnimationChainList chains = (AnimationChainList)GetMember(CurrentEnemyData.AnimationsFile);
            Visual.AnimationChains = chains;
            Visual.CurrentChainName = CurrentEnemyData.DefaultChainName; 

        }
	}
}

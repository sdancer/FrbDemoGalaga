using System.Collections.Generic;
using System.Threading;
using FlatRedBall;
using FlatRedBall.Math.Geometry;
using FlatRedBall.ManagedSpriteGroups;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Utilities;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using FlatRedBall.Localization;

namespace FrbDemoGalaga
{
	public static partial class GlobalContent
	{
		
		public static Microsoft.Xna.Framework.Graphics.Texture2D GalagaSpriteSheet { get; set; }
		public static FlatRedBall.Graphics.BitmapFont nesfont { get; set; }
		public static Microsoft.Xna.Framework.Graphics.Texture2D nesfontTexture { get; set; }
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			switch(memberName)
			{
				case  "GalagaSpriteSheet":
					return GalagaSpriteSheet;
				case  "nesfont":
					return nesfont;
				case  "nesfontTexture":
					return nesfontTexture;
			}
			return null;
		}
		public static object GetFile (string memberName)
		{
			switch(memberName)
			{
				case  "GalagaSpriteSheet":
					return GalagaSpriteSheet;
				case  "nesfont":
					return nesfont;
				case  "nesfontTexture":
					return nesfontTexture;
			}
			return null;
		}
		public static bool IsInitialized { get; private set; }
		public static bool ShouldStopLoading { get; set; }
		static string ContentManagerName = "Global";
		public static void Initialize ()
		{
			
			GalagaSpriteSheet = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/globalcontent/galagaspritesheet.png", ContentManagerName);
			nesfont = FlatRedBallServices.Load<FlatRedBall.Graphics.BitmapFont>(@"content/globalcontent/nesfont.fnt", ContentManagerName);
			nesfontTexture = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/globalcontent/nesfonttexture.png", ContentManagerName);
						IsInitialized = true;
		}
		public static void Reload (object whatToReload)
		{
		}
		
		
	}
}

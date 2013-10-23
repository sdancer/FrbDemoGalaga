using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using Microsoft.Xna.Framework;

#if !FRB_MDX
using System.Linq;
#endif

namespace FrbDemoGalaga
{
	internal static class CameraSetup
	{
			internal static void SetupCamera (Camera cameraToSetUp, GraphicsDeviceManager graphicsDeviceManager)
			{
				FlatRedBallServices.GraphicsOptions.SetResolution(448, 576);
				#if WINDOWS_PHONE || WINDOWS_8 || IOS || ANDROID
				graphicsDeviceManager.SupportedOrientations = DisplayOrientation.Portrait;
				#endif
				cameraToSetUp.UsePixelCoordinates(false, 250, 322);
			}
			internal static void ResetCamera (Camera cameraToReset)
			{
				cameraToReset.X = 0;
				cameraToReset.Y = 0;
				cameraToReset.XVelocity = 0;
				cameraToReset.YVelocity = 0;
			}

	}
}

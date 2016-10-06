using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using HockeyApp.iOS;


namespace DemoIntegration.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			var manager = BITHockeyManager.SharedHockeyManager;
			manager.LogLevel = BITLogLevel.Verbose;
			//manager.DebugLogEnabled = true;
			manager.Configure("63fba92ef9e645ee8fa5c15fed85fad3");
			manager.StartManager();
			manager.Authenticator.AuthenticateInstallation(); // This line is obsolete in crash only builds

			HockeyApp.MetricsManager.TrackEvent("Custom Event",
  						new Dictionary<string, string> { { "property", "value" } },
												new Dictionary<string, double> { { "time", 1.0 } });

			return base.FinishedLaunching(app, options);
		}
	}
}

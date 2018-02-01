using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using WorkingWithFiles;

using Xamarin.Forms;

namespace WorkingWithFiles.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : 
	global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate // superclass new in 1.3
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());  // method is new in 1.3

			return base.FinishedLaunching (app, options);
		}
	}
}


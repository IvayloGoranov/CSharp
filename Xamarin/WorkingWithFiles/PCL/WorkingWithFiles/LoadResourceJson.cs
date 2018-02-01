﻿using System;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WorkingWithFiles
{
	public class LoadResourceJson : ContentPage
	{
		public LoadResourceJson()
		{
			#region How to load an Json file embedded resource
			var assembly = typeof(LoadResourceText).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("WorkingWithFiles.PCLJsonResource.json");

			Earthquake[] earthquakes;


			using (var reader = new System.IO.StreamReader(stream))
			{

				var json = reader.ReadToEnd();
				var rootobject = JsonConvert.DeserializeObject<Rootobject>(json);

				earthquakes = rootobject.earthquakes;
			}
			#endregion

			var listView = new ListView();
			listView.ItemsSource = earthquakes;


			Content = new StackLayout
			{
				Padding = new Thickness(0, 20, 0, 0),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					new Label { Text = "Embedded Resource JSON File (PCL)",
						FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
						FontAttributes = FontAttributes.Bold
					}, listView
				}
			};

			// NOTE: use for debugging, not in released app code!
			//foreach (var res in assembly.GetManifestResourceNames()) 
			//	System.Diagnostics.Debug.WriteLine("found resource: " + res);
		}
	}
}


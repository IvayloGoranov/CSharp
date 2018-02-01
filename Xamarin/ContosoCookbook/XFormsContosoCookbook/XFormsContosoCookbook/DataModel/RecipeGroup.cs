﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFormsContosoCookbook.DataModel
{
	public class RecipeGroup
	{
		[JsonProperty("UniqueId")]
		public string ID { get; set; }
		public string Title { get; set; }
		public string Subtitle { get; set; }
		public string ImagePath { get; set; }
		public string GroupImagePath { get; set; }
		public string Description { get; set; }
		[JsonProperty("Items")]
		public List<Recipe> Recipes { get; set; }
	}
}

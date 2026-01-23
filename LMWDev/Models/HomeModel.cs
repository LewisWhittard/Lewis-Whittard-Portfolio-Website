using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMWDev.Models
{
	public class HomeModel
	{
		public bool Meta { get; set; } = false;
        public bool ShouldNotBeIndexed { get; set; } = false;
        public bool BackgroundEnabled { get; set; }
        public SearchViewModel Search { get; set; }

        public HomeModel(bool backgroundEnabled)
        {
            BackgroundEnabled = backgroundEnabled;
        }
    }
}

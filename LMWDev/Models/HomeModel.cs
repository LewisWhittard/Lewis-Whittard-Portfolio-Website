using System.Collections.Generic;
using UIFactory.Factory.Interface;

namespace LMWDev.Models
{
	public class HomeModel
	{
		public bool FlexibleMeta { get; set; }
        List<IUI> UIs { get; set; }

        public HomeModel(bool FelxaibleMeta, List<IUI> uIS)
        {
            FlexibleMeta = false;
            UIs = uIS;
        }
    }
}

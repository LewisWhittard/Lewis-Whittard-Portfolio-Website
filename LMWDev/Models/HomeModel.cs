using System.Collections.Generic;
using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace LMWDev.Models
{
	public class HomeModel
	{
		public bool FlexibleMeta { get; set; }
        List<IConcreteUI> UIs { get; set; }

        public HomeModel(bool FelxaibleMeta, List<IConcreteUI> uIS)
        {
            FlexibleMeta = false;
            UIs = uIS;
        }
    }
}

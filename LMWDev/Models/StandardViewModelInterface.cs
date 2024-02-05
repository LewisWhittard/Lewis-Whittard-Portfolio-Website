using LMW_Infrastructure.Model;
using System.Collections.Generic;

namespace LMWDev.Models.ViewModel
{
	internal interface StandardViewModelInterface
	{
		public List<IContent> Content { get; set; }
		public IJsonLD? JsonLD { get; set; }
	}
}

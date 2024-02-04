using LMW_Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMW_Infrastructure.ViewModel
{
	internal interface StandardViewModelInterface
	{
		public List<IContent> Content { get; set; }
		public IJsonLD? JsonLD { get; set; }
	}
}

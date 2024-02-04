using LMW_Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMW_Infrastructure.ViewModel
{
	public class homePageViewModel : IHomePageViewModel, StandardViewModelInterface
	{
		public List<IContent> Content { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public IJsonLD? JsonLD { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	}
}

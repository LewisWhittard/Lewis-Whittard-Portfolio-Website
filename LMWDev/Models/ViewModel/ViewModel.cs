using LMW_Infrastructure.Model;
using System;
using System.Collections.Generic;

namespace LMWDev.Models.ViewModel
{
	public class ViewModel : StandardViewModelInterface
	{
		public List<IContent> Content { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public IJsonLD? JsonLD { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	}
}

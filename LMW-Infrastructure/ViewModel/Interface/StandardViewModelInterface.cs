using LMW_Infrastructure.Model;

namespace LMW_Infrastructure.ViewModel
{
	internal interface StandardViewModelInterface
	{
		public List<IContent> Content { get; set; }
		public IJsonLD? JsonLD { get; set; }
	}
}

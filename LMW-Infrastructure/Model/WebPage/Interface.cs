using System.ComponentModel;

namespace LMW_Infrastructure.Model
{
	public interface IWebPage
	{
		public string URL { get; set; }
		public string SubDomain { get; set; }
		List<Content> Content { get; set; }
	}
}
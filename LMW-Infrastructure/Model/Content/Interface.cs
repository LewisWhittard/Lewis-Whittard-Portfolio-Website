namespace LMW_Infrastructure.Model
{
	public interface IContent
	{
		public int WebPageId { get; set; }
		public WebPage WebPage { get; set; }
	}
}

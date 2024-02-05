namespace LMW_Infrastructure.Model
{
	public interface IContent
	{
		public int WebPageId { get; set; }
		public WebPage WebPage { get; set; }
		public List<ContentComponent> Components { get; set; }
		public ContentType ContentType { get; set; }
		public string HTML { get; set; }
	}
}

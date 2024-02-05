namespace LMW_Infrastructure.Model
{
	public class Content : IContent, IDatabaseTableStandards
	{
		public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Inactive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int WebPageId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public WebPage WebPage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public List<ContentComponent> Components { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		ContentType IContent.ContentType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	}
}

namespace LMW_Infrastructure.Model
{
	public class WebPage : IWebPage, IDatabaseTableStandards
	{
		public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Inactive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string URL { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string SubDomain { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public List<Content> Content { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	}
}

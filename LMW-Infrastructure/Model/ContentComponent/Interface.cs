namespace LMW_Infrastructure.Model
{
	public interface IContentComponent
	{
		public int ContentId { get; set; }
		public Content Content { get; set; }
		public int DisplayOrder { get; set; }
		public string Value { get; set; }
		public string? Alt {  get; set; }
		public HTMLContentComponentType HMTLContentComponentType { get; set; }
        public ContentComponentType ContentComponentType { get; set; }
		public string? ItemProp { get; set; }

    }
}

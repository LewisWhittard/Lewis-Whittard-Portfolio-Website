namespace LMW_Infrastructure.Model
{
	public interface IContentComponent
	{
		public int ContentId { get; set; }
		public Content Content { get; set; }
		public int DisplayOrder { get; set; }
		public string Value { get; set; }
		public string? Alt {  get; set; }
		public ContentComponentType ComponentType { get; set; }
	}
}

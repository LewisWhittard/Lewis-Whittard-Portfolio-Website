namespace Page_Library.Page.Entities.SearchResult.Interface
{
    public interface ISearchResult
    {
        public string ExternalId { get; }
        public string Title { get; }
        public string Description { get; }
        public string MetaImageUrl { get; }
        public string MetaImageAlt { get; }
        public string Category { get; }
    }
}

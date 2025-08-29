namespace Page_Library.Search.Entities.SearchResult.Interface
{
    public class ISearchResult
    {
        public long ID { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public long ImageID { get; private set; }
        public string Category { get; private set; }
    }
}

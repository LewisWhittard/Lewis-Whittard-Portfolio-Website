using Page_Library.Content.Entities.Content.Interface;

namespace Page_Library.Search.Entities.SearchResult.Interface
{
    public interface ISearchResult
    {
        public int ID { get;  }
        public string Title { get; }
        public string Description { get; }
        public int ContentID { get; }
        public IContent Content { get; }
        public string Category { get; }

        public abstract void SetContent(IContent content);
    }
}

using Page_Library.Content.Entities.Content;

namespace Page_Library.Page.Entities.SearchResult.Interface
{
    public interface ISearchResult
    {
        public string ExternalId { get; }
        public string Title { get; }
        public string Description { get; }
        public int ContentID { get; }
        public Image Content { get; }
        public string Category { get; }

        public abstract void SetContent(Image content);
    }
}

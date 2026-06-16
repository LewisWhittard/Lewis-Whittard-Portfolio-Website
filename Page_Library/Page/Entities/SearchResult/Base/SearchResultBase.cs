using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Entities.SearchResult.Interface;
namespace Page_Library.Page.Entities.SearchResult.Base
{
    public abstract class SearchResultBase : ISearchResult
    {
        public string ExternalId { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string MetaImageUrl { get; private set; }
        public string MetaImageAlt { get; private set; }
        public string Category { get; private set; }

        public SearchResultBase(IPage page)
        {
            ExternalId = page.ExternalId;
            Title = page.Title;
            Description = page.Meta.MetaDescription;
            MetaImageUrl = page.Meta.MetaImageUrl;
            MetaImageAlt = page.Meta.MetaImageAlt;
            Category = page.Category;
        }
    }
}

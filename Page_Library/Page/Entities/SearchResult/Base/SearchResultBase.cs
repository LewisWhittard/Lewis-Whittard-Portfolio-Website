using Page_Library.Content.Entities.Content;
using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Entities.SearchResult.Interface;
using Page_Library.Search.Entities.SearchResult.DTO;

namespace Page_Library.Page.Entities.SearchResult.Base
{
    public abstract class SearchResultBase : ISearchResult
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int ContentID { get; private set; }
        public Image Content { get; private set; }
        public string Category { get; private set; }

        public SearchResultBase(IPage page)
        {
            Title = page.Title;
            Description = page.Meta.MetaDescription;
            ContentID = page.Meta.Content.ID;
            Content = (Image)page.Meta.Content;
            Category = page.Category;
        }

        public void SetContent(Image content)
        {
            Content = content;
        }
    }
}

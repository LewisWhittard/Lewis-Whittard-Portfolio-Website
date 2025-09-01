using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Search.Entities.SearchResult.DTO;
using Page_Library.Search.Entities.SearchResult.Interface;

namespace Page_Library.Search.Entities.SearchResult.Base
{
    public abstract class SearchResultBase : ISearchResult
    {
        public int ID { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int ContentID { get; private set; }
        public IContent Content { get; private set; }
        public string Category { get; private set; }

        public SearchResultBase(SearchResultDTO dto)
        {
            ID = dto.ID;
            Title = dto.Title;
            Description = dto.Description;
            ContentID = dto.ContentID;
            Category = dto.Category;
        }

        public void SetContent(IContent content)
        {
            Content = content;
        }
    }
}

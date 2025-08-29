using Page_Library.Search.Entities.SearchResult.Interface;

namespace Page_Library.Search.Entities.SearchResult.Base
{
    public abstract class SearchResultBase : ISearchResult
    {
        public long ID { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public long ImageID { get; private set; }
        public string Category { get; private set; }

        public SearchResultBase(long id, string title, string description, long imageID, string category)
        {
            ID = id;
            Title = title;
            Description = description;
            ImageID = imageID;
            Category = category;
        }


    }
}

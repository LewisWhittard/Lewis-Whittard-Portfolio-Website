using Page_Library.Page.Entities.Page.Interface;

namespace Page_Library.Page.Repository.Interface
{
    public interface IPageRepository
    {
        public abstract IPage GetPage(string Id);
        public abstract List<IPage> GetPages(string? searchTerm, string Category);

    }
}

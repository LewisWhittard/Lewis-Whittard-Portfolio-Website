using Page_Library.Page.Entities.Page.Interface;

namespace Page_Library.Page.Repository.Interface
{
    public interface IPageRepository
    {
        public abstract List<IPage> GetPage(int Id);
    }
}

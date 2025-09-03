using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Repository.Interface;

namespace Page_Library.Page.Repository.Base
{
    public abstract class PageRepositoryBase : IPageRepository
    {
        public abstract List<IPage> GetPage(int Id);
    }
}

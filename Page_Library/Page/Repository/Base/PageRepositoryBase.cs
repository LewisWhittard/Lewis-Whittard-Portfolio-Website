using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Repository.Interface;

namespace Page_Library.Page.Repository.Base
{
    public abstract class PageRepositoryBase : IPageRepository
    {
        protected PageRepositoryBase()
        {
            
        }

        public abstract IPage GetPage(string Id);
    }
}

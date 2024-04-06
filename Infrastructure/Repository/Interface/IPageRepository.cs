using Infrastructure.Models.Data.Page;
using Infrastructure.Models.Data.Page.Interface;

namespace Infrastructure.Repository.Interface
{
    public interface IPageRepository
    {
        public Page GetByPageName(string PageName);
    }
}

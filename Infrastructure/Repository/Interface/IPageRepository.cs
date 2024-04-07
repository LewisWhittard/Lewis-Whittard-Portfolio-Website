using Infrastructure.Models.Data.Page;

namespace Infrastructure.Repository.Interface
{
    public interface IPageRepository
    {
        public Page GetByPageName(string PageName);
    }
}

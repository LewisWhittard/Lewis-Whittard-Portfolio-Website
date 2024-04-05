using Infrastructure.Models.Data.Page.Interface;

namespace Infrastructure.Repository.Interface
{
    public interface IPageRepository
    {
        public IPage Get(string PageName);
    }
}

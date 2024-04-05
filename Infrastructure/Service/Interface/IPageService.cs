using Infrastructure.Models.Data.Page.Interface;

namespace Infrastructure.Service.Interface
{
    public interface IPageService
    {
        public IPage Get(string PageName);
    }
}

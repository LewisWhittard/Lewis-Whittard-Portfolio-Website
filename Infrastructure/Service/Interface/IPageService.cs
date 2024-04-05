using Infrastructure.Models.Data.Page;
using Infrastructure.Models.Data.Page.Interface;

namespace Infrastructure.Service.Interface
{
    public interface IPageService
    {
        public Page Get(string PageName);
    }
}

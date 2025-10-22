using Page_Library.Page.Entities.Page.Interface;

namespace Page_Library.Page.Service.Interface
{
    public interface IPageService
    {
        public abstract IPage GetPage(string id);
    }
}

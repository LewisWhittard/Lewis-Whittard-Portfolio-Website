using Infrastructure.Models.Data.Carousel;
using Infrastructure.Models.Data.CarouselCard;
using Infrastructure.Models.Data.InformationBlock;
using Infrastructure.Models.Data.Shared.Card;
using Infrastructure.Models.Data.Shared.Image;
using Infrastructure.Models.Data.Table;
using Infrastructure.Models.Data.Video;
using Infrastructure.Repository.Page.Interface;

namespace Infrastructure.Repository.Page
{
    public class MockPageRepository : IPageRepository
    {
        private List<Models.Data.Page.Page> _pages;

        public MockPageRepository()
        {
            _pages = new List<Models.Data.Page.Page>();

            _pages.Add(new Models.Data.Page.Page("First", null, null, null, null, null, null, "FirstGUID", 0, false, false));
            _pages.Add(new Models.Data.Page.Page("Second", null, null, null, null, null, null, "SecondGUID", 0, false, false));
            _pages.Add(new Models.Data.Page.Page("Deleted", null, null, null, null, null, null, "DeletedGUID", 0, true, false));
            _pages.Add(new Models.Data.Page.Page("IncludeInactive", null, null, null, null, null, null, "IncludeInactiveGUID", 0, false, true));
            _pages.Add(new Models.Data.Page.Page("ExcludeInactive", null, null, null, null, null, null, "ExcludeInactiveGUID", 0, true, false));
        }

        public List<Models.Data.Page.Page> GetPages(string PageName)
        {
            return _pages;
        }
    }
}

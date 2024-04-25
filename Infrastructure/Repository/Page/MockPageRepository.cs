using Infrastructure.Repository.Page.Interface;

namespace Infrastructure.Repository.Page
{
    public class MockPageRepository : IPageRepository
    {
        private List<Models.Data.Page.Page> _pages {  get; set; }

        public MockPageRepository()
        {
            _pages = new List<Models.Data.Page.Page>()
            {
                new Models.Data.Page.Page() {PageName = "HomePage"},
                new Models.Data.Page.Page() {PageName = "SecondPage"}
            };
            

            

        }

        public Models.Data.Page.Page GetByPageName(string pageName)
        {
            Models.Data.Page.Page result = _pages.Where(x => x.PageName == pageName).FirstOrDefault();
            return result;
        }
    }
}

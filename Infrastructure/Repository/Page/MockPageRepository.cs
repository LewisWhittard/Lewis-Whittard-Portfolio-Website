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
                new Models.Data.Page.Page() {PageName = "FirstPage", Deleted = false, Inactive = false},
                new Models.Data.Page.Page() {PageName = "SecondPage", Deleted = false, Inactive = false},
                new Models.Data.Page.Page() {PageName = "Deleted", Deleted = true, Inactive = false},
                new Models.Data.Page.Page() {PageName = "IncludeInactive", Deleted = false, Inactive = true},
                new Models.Data.Page.Page() {PageName = "ExcludeInactive", Deleted = false, Inactive = true}
            };
            

            

        }

        public List<Models.Data.Page.Page> GetPages(string PageName)
        {
            return _pages;
        }
    }
}

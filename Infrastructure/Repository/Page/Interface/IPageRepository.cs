namespace Infrastructure.Repository.Page.Interface
{
    public interface IPageRepository
    {
        public Models.Data.Page.Page GetByPageName(string PageName);
    }
}

namespace Infrastructure.Repository.Page.Interface
{
    public interface IPageRepository
    {
        public List<Models.Data.Page.Page> GetPages(string PageName);
    }
}

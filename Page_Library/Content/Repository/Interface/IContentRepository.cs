using Page_Library.Content.Entities.Content.Interface;

namespace Page_Library.Content.Repository.Interface
{
    public interface IContentRepository
    {
        public abstract IContent GetContentById(int id);
    }
}
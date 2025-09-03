using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Content.Repository.Interface;

namespace Page_Library.Content.Repository.Base
{
    public abstract class ContentRepositoryBase : IContentRepository
    {
        public abstract IContent GetContent(int id);
    }
}

using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.ContentBlock.Interface;

namespace Page_Library.Page.Factory.Interface
{
    public interface IContentBlockFactory
    {
        public abstract IContentBlock CreateContentBlock(ContentBlockDTO dto, IContent? content);
    }
}


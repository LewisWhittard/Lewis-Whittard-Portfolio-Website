using Page_Library.Page.Entities.ContentBlock.Interface;
using Page_Library.Page.Entities.Page.Base;
using Page_Library.Page.Entities.Page.DTO;

namespace Page_Library.Page.Entities.Page
{
    public class Page : PageBase
    {
        public Page(PageDTO page, List<IContentBlock> contentBlocks) : base(page,contentBlocks)
        {
        }
    }
}

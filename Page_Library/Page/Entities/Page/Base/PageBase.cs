using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.MetaData.DTO;

namespace Page_Library.Page.Entities.Page.Base
{
    public abstract class PageBase
    {
        public int ExternalId { get; private set; }
        public string Title { get; private set; }
        public string PublishDate { get; private set; }
        public MetaDTO Meta { get; private set; }
        public List<ContentBlockDTO> ContentBlocks { get; private set; }
    }
}

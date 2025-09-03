using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.MetaData.DTO;

namespace Page_Library.Page.Entities.Page.Base
{
    public abstract class PageBase
    {
        public int externalId { get; private set; }
        public string title { get; private set; }
        public string publishDate { get; private set; }
        public MetaDTO meta { get; private set; }
        public List<ContentBlockDTO> contentBlocks { get; private set; }
    }
}

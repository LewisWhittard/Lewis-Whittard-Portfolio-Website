using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.MetaData.DTO;

namespace Page_Library.Page.Entities.Page.Interface
{
    public interface IPage
    {
        public int externalId { get; }
        public string title { get; }
        public string publishDate { get; }
        public MetaDTO meta { get; }
        public List<ContentBlockDTO> contentBlocks { get; }
    }
}

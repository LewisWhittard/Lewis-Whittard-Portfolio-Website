using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.MetaData.DTO;

namespace Page_Library.Page.Entities.Page.Interface
{
    public interface IPage
    {
        public int ExternalId { get; }
        public string Title { get; }
        public string PublishDate { get; }
        public MetaDTO Meta { get; }
        public List<ContentBlockDTO> ContentBlocks { get; }
    }
}

using Page_Library.Content.Repository.Interface;
using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.ContentBlock.Interface;
using Page_Library.Page.Entities.MetaData.DTO;
using Page_Library.Page.Factory.Interface;

namespace Page_Library.Page.Entities.Page.Interface
{
    public interface IPage
    {
        public int ExternalId { get; }
        public string Title { get; }
        public string PublishDate { get; }
        public MetaDTO Meta { get; }
        public List<IContentBlock> ContentBlocks { get; }

        public abstract void SetUpPolymorphContentBlocks(IContentRepository contentRepository, IContentBlockFactory contentBlockFactory);

    }
}

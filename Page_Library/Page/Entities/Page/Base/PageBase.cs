using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Page.Entities.MetaData.DTO;
using Page_Library.Page.Entities.Page.DTO;

namespace Page_Library.Page.Entities.Page.Base
{
    public abstract class PageBase
    {
        public int ExternalId { get; private set; }
        public string Title { get; private set; }
        public string PublishDate { get; private set; }
        public MetaDTO Meta { get; private set; }
        public List<IContent> ContentBlocks { get; private set; }

        protected PageBase(PageDTO page)
        {
            ExternalId = page.ExternalId;
            Title = page.Title;
            PublishDate = page.PublishDate;
            Meta = page.Meta;
        }
    }
}

using Page_Library.Content.Repository.Interface;
using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.ContentBlock.Interface;
using Page_Library.Page.Entities.MetaData;
using Page_Library.Page.Entities.MetaData.Interface;
using Page_Library.Page.Entities.Page.DTO;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Factory.Interface;

namespace Page_Library.Page.Entities.Page.Base
{
    public abstract class PageBase : IPage
    {
        public string ExternalId { get; private set; }
        public string Title { get; private set; }
        public string PublishDate { get; private set; }
        public string Category {  get; private set; }
        public IMeta Meta { get; private set; }
        public List<IContentBlock> ContentBlocks { get; private set; }
        private List<ContentBlockDTO>? ContentBlockDTO;

        protected PageBase(PageDTO dto)
        {
            ExternalId = dto.ExternalId;
            Title = dto.Title;
            PublishDate = dto.PublishDate;
            Category = dto.Category;
            Meta = new Meta(dto.Meta);
            ContentBlockDTO = dto.ContentBlocks;
        }

        public void SetUpPolymorphContentBlocks(IContentRepository contentRepository, IContentBlockFactory contentBlockFactory)
        {
            List<IContentBlock> contentBlocks = new List<IContentBlock>();

            if (ContentBlockDTO == null)
            {
                // Log or handle the null case appropriately
                return;
            }

            foreach (var item in ContentBlockDTO)
            {
                try
                {
                    if (item.BlockType == "Video" || item.BlockType == "Image")
                    {
                        var mediaContent = contentRepository.GetContent((int)item.MediaId);
                        contentBlocks.Add(contentBlockFactory.CreateContentBlock(item, mediaContent));
                    }
                    else
                    {
                        contentBlocks.Add(contentBlockFactory.CreateContentBlock(item, null));
                    }
                }
                catch (Exception ex)
                {
                    // Log the error, maybe continue with the next item
                    Console.WriteLine($"Error processing item with MediaId {item.MediaId}: {ex.Message}");
                }
            }

            ContentBlocks = contentBlocks;
        }
    }
}

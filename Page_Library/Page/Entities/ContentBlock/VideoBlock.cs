using Page_Library.Content.Entities.Content;
using Page_Library.Page.Entities.ContentBlock.Base;
using Page_Library.Page.Entities.ContentBlock.DTO;

namespace Page_Library.Page.Entities.ContentBlock
{
    public class VideoBlock : ContentBlockBase
    {
        public string Description { get; private set; }
        public string ThumbnailURL { get; private set; }
        public string URL { get; private set; }
        public string Title { get; private set; }   

        public VideoBlock(ContentBlockDTO dto) : base(dto)
        {
            Description = dto.Description;
            ThumbnailURL = dto.ThumbnailUrl;
            URL = dto.VideoUrl;
            Title = dto.VideoTitle;
        }
    }


}

using Page_Library.Content.Entities.Content;
using Page_Library.Page.Entities.ContentBlock.Base;
using Page_Library.Page.Entities.ContentBlock.DTO;

namespace Page_Library.Page.Entities.ContentBlock
{
    public class ImageBlock : ContentBlockBase
    {
        public int MediaId { get; private set; }
        public Image Content { get; private set; }

        public ImageBlock(ContentBlockDTO dto, Image content) : base(dto)
        {
            MediaId = (int)dto.MediaId;
            Content = content;
        }
    }


}

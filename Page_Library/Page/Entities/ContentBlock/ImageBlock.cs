using Page_Library.Content.Entities.Content;
using Page_Library.Page.Entities.ContentBlock.Base;
using Page_Library.Page.Entities.ContentBlock.DTO;

namespace Page_Library.Page.Entities.ContentBlock
{
    public class ImageBlock : ContentBlockBase
    {
        public string Alt { get; private set; }
        public string URL { get; private set; }

        public ImageBlock(ContentBlockDTO dto) : base(dto)
        {
            URL = dto.ImageUrl;
            Alt = dto.Alt;
        }
    }


}

using Page_Library.Page.Entities.ContentBlock.Base;
using Page_Library.Page.Entities.ContentBlock.DTO;

namespace Page_Library.Page.Entities.ContentBlock
{
    public class ImageBlock : ContentBlockBase
    {
        public int MediaId { get; set; }
        public string AltText { get; set; }

        public ImageBlock(ContentBlockDTO dto) : base(dto)
        {
            MediaId = dto.MediaId ?? -1;
            AltText = dto.AltText;
        }
    }


}

using Page_Library.Page.Entities.ContentBlock.Base;
using Page_Library.Page.Entities.ContentBlock.DTO;

namespace Page_Library.Page.Entities.ContentBlock
{
    public class VideoBlock : ContentBlockBase
    {

        public int MediaId { get; set; }
        public string Caption { get; set; }

        public VideoBlock(ContentBlockDTO dto) : base(dto)
        {
            MediaId = dto.MediaId ?? -1;
            dto.Caption = Caption;
        }
    }


}

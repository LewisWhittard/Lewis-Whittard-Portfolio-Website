using Page_Library.Content.Entities.Content;
using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Page.Entities.ContentBlock.Base;
using Page_Library.Page.Entities.ContentBlock.DTO;

namespace Page_Library.Page.Entities.ContentBlock
{
    public class VideoBlock : ContentBlockBase
    {

        public int MediaId { get; private set; }
        public string Caption { get; private set; }
        public Video Content { get; private set; }

        public VideoBlock(ContentBlockDTO dto, Video content) : base(dto)
        {
            MediaId = (int)dto.MediaId;
            Caption = dto.Caption;
            Content = content;
        }
    }


}

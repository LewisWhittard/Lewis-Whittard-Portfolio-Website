using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Page.Entities.ContentBlock.Base;
using Page_Library.Page.Entities.ContentBlock.DTO;

namespace Page_Library.Page.Entities.ContentBlock
{
    public class VideoBlock : ContentBlockBase
    {

        public int MediaId { get; private set; }
        public string Caption { get; private set; }
        public IContent Content { get; private set; }

        public VideoBlock(ContentBlockDTO dto, IContent Content) : base(dto)
        {
            MediaId = dto.MediaId ?? -1;
            Caption = dto.Caption;
            dto.content
        }
    }


}

using Page_Library.Page.Entities.ContentBlock.Base;
using Page_Library.Page.Entities.ContentBlock.DTO;

namespace Page_Library.Page.Entities.ContentBlock
{
    public class ParagraphBlock : ContentBlockBase
    {
        public string BodyText { get; private set; }

        public ParagraphBlock(ContentBlockDTO dto) : base(dto)
        {
            BodyText = dto.BodyText;
        }
    }


}

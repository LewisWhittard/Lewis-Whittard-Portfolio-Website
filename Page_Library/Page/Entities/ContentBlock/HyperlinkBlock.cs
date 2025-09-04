using Page_Library.Page.Entities.ContentBlock.Base;
using Page_Library.Page.Entities.ContentBlock.DTO;

namespace Page_Library.Page.Entities.ContentBlock
{
    public class HyperlinkBlock : ContentBlockBase
    {

        public string Url { get; private set; }
        public string LinkText { get; private set; }

        public HyperlinkBlock(ContentBlockDTO dto) : base(dto)
        {
            Url = dto.Url;
            LinkText = dto.LinkText;
        }
    }


}

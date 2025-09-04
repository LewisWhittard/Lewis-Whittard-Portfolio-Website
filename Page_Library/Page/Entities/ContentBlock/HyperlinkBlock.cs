using Page_Library.Page.Entities.ContentBlock.Base;

namespace Page_Library.Page.Entities.ContentBlock
{
    public class HyperlinkBlock : ContentBlockBase
    {
        public string Url { get; set; }
        public string LinkText { get; set; }
    }


}

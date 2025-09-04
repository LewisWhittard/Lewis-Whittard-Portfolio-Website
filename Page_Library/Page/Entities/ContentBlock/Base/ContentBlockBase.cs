using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.ContentBlock.Interface;


namespace Page_Library.Page.Entities.ContentBlock.Base
{
    public class ContentBlockBase : IContentBlock
    {
        public string BlockType { get; private set; }

        public string Alignment { get; private set; }

        public ContentBlockBase(ContentBlockDTO dto)
        {
            BlockType = dto.BlockType;
            Alignment = dto.Alignment;
        }
    }
}

using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Page.Entities.ContentBlock.Base;
using Page_Library.Page.Entities.ContentBlock.DTO;

namespace Page_Library.Page.Entities.ContentBlock
{
    public class ImageBlock : ContentBlockBase
    {
        public int MediaId { get; private set; }
        public IContent Content { get; private set; }
        public string AltText { get; private set; }

        public ImageBlock(ContentBlockDTO dto, IContent content) : base(dto)
        {
            MediaId = (int)dto.MediaId;
            AltText = dto.AltText;
            Content = content;
        }
    }


}

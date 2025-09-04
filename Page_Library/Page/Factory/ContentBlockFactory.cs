using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Page.Entities.ContentBlock;
using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.ContentBlock.Interface;
using Page_Library.Page.Factory.B;
using Page_Library.Page.Factory.Base;

namespace Page_Library.Page.Factory
{
    public class ContentBlockFactory : ContentBlockFactoryBase
    {
        public override IContentBlock CreateContentBlock(ContentBlockDTO dto, IContent content)
        {
            switch (dto.BlockType)
            {
                case "Header":
                    return new HeaderBlock(dto);
                case "Hyperlink":
                    return new HyperlinkBlock(dto);
                case "Image":
                    return new ImageBlock(dto, content);
                case "Paragraph":
                    return new ParagraphBlock(dto);
                case "Video":
                    return new VideoBlock(dto, content);
                default:
                    throw new ArgumentException($"Unsupported block type: {dto.BlockType}");
            }

        }
    }
}

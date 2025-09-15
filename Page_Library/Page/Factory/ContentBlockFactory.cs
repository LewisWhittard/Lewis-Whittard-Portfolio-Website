using Page_Library.Content.Entities.Content;
using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Page.Entities.ContentBlock;
using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.ContentBlock.Interface;
using Page_Library.Page.Factory.Base;

namespace Page_Library.Page.Factory
{
    public class ContentBlockFactory : ContentBlockFactoryBase
    {
        public override IContentBlock CreateContentBlock(ContentBlockDTO dto, IContent? content)
        {
            switch (dto.BlockType)
            {
                switch (dto.BlockType)
            {
                case "Header":
                    return new HeaderBlock(dto);

                case "Hyperlink":
                    return new HyperlinkBlock(dto);

                case "Image":
                    if (content is Image imageContent)
                    {
                        return new ImageBlock(dto, imageContent);
                    }
                    throw new InvalidCastException("Content is not of type ImageContent");

                case "Paragraph":
                    return new ParagraphBlock(dto);

                case "Video":
                    if (content is Video videoContent)
                    {
                        return new VideoBlock(dto, videoContent);
                    }
                    throw new InvalidCastException("Content is not of type VideoContent");

                default:
                    throw new ArgumentException($"Unsupported block type: {dto.BlockType}");
            }
        }
    }
}
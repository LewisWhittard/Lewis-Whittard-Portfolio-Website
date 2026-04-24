using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Content.Repository.Interface;
using Page_Library.Page.Entities.MetaData.DTO;
using Page_Library.Page.Entities.MetaData.Interface;
using Page_Library.Page.Entities.Page.DTO;
using System.Runtime.CompilerServices;

namespace Page_Library.Page.Entities.MetaData.Base
{
    public class MetaBase : IMeta
    {
        public string MetaTitle { get; private set; }

        public string MetaDescription { get; private set; }

        public List<string> MetaKeywords { get; private set; }

        public int? MetaImageId { get; private set; }

        public IContent Content { get; private set; }

        public MetaBase(MetaDTO dto)
        {
            MetaTitle = dto.MetaTitle;
            MetaDescription = dto.MetaDescription;
            MetaKeywords = dto.MetaKeywords;
            MetaImageId = dto.MetaImageId;
        }

        public MetaBase(MetaBlockGridDto metaBlockGridDto)
        {
            if (metaBlockGridDto?.Items == null || metaBlockGridDto.Items.Count == 0)
                return;

            var block = metaBlockGridDto.Items[0].Content.Properties;

            MetaTitle = block.MetaTitle;
            MetaDescription = block.MetaDescription;
            MetaKeywords = block.MetaKeywords?.Split(",").ToList() ?? Array.Empty<string>().ToList();
            MetaImageId = block.MetaImageId;
        }


        public void SetContent(IContentRepository contentRepository)
        {
            Content = contentRepository.GetContent((int)MetaImageId);
        }
    }
}

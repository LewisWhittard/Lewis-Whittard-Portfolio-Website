using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Content.Repository.Interface;
using Page_Library.Page.Entities.MetaData.DTO;
using Page_Library.Page.Entities.MetaData.Interface;

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

        public void SetContent(IContentRepository contentRepository)
        {
            Content = contentRepository.GetContent((int)MetaImageId);
        }
    }
}

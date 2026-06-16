using Page_Library.Page.Entities.MetaData.DTO;
using Page_Library.Page.Entities.MetaData.Interface;

namespace Page_Library.Page.Entities.MetaData.Base
{
    public class MetaBase : IMeta
    {
        public string MetaTitle { get; private set; }

        public string MetaDescription { get; private set; }

        public List<string> MetaKeywords { get; private set; }

        public string MetaImageUrl { get; private set; }

        public string MetaImageAlt { get; private set; }

        public MetaBase(MetaDTO dto)
        {
            MetaTitle = dto.MetaTitle;
            MetaDescription = dto.MetaDescription;
            MetaKeywords = dto.MetaKeywords;
            MetaImageUrl = dto.MetaImageUrl;
            MetaImageAlt = dto.MetaImageAlt;
        }
    }
}

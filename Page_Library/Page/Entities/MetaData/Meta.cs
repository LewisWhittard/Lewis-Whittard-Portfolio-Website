using Page_Library.Page.Entities.MetaData.Base;
using Page_Library.Page.Entities.MetaData.DTO;
using Page_Library.Page.Entities.Page.DTO;

namespace Page_Library.Page.Entities.MetaData
{
    public class Meta : MetaBase
    {
        public Meta(MetaDTO dto) : base(dto)
        {
        }

        public Meta(MetaBlockGridDto metaBlockGridDto) : base(metaBlockGridDto)
        {
        }
    }
}

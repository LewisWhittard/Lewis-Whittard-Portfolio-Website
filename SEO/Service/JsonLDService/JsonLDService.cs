using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;
using SEO.Service.JsonLDService.Interface;

namespace SEO.Service.JsonLDService
{
    public class JsonLDService : IJsonLDService
    {
        public List<IJsonLDData> GetByPageName(string PageName, IData data)
        {
            return GetByPageName(PageName).Where(x => x.DataId == data.Id && data.UIConcreteType == x.UIConcreteType).ToList(); ;
        }

        public List<IJsonLDData> GetByPageName(string PageName)
        {
            return null;
        }
    }
}

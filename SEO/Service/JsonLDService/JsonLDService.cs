using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;
using SEO.Service.JsonLDService.Interface;

namespace SEO.Service.JsonLDService
{
    public class JsonLDService : IJsonLDService
    {
        public List<IJsonLDData> GetByPageNameAndSuperClassDataIdAndUIConcreteType(string pageName, IData data)
        {
            //return GetByPageName(pageName).Where(x => x.SuperClassDataId == data.Id && data.UIConcreteType == x.UIConcreteType).ToList();
            return new List<IJsonLDData>();

        }

        public List<IJsonLDData> GetByPageName(string pageName)
        {
            return new List<IJsonLDData>();
        }
    }
}

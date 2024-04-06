using Infrastructure.Models.Data.Interface;
using SEO.Models.Alt.Interface;
using SEO.Service.AltService.Interface;

namespace SEO.Service.AltService
{
    public class AltService : IAltService
    {
        public List<IAltData> GetByPageName(string pageName)
        {
            return new List<IAltData>();
        }

        public List<IAltData> GetByPageName(string pageName, IData data)
        {
            return GetByPageName(pageName).Where(x => x.DataId == data.Id && data.UIConcreteType == x.UIConcreteType).ToList();
        }
    }
}

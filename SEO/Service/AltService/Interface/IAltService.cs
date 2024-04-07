using Infrastructure.Models.Data.Interface;
using SEO.Models.Alt;
using SEO.Models.Alt.Interface;

namespace SEO.Service.AltService.Interface
{
    public interface IAltService
    {
        public List<IAltData> GetByPageName(string pageName);
        public List<IAltData> GetByPageNameAndSuperClassDataIdAndUIConcreteType(string pageName, IData data);
    }
}

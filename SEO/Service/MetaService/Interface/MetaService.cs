using Infrastructure.Models.Data.Interface;
using SEO.Models.Meta.Interface;

namespace SEO.Service.MetaService.Interface
{
    public interface IMetaService
    {
        public List<IMetaData> GetByPageName(string data);
    }
}

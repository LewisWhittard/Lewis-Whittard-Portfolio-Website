using Infrastructure.Models.Data.Interface;
using SEO.Models.Alt;

namespace SEO.Service.AltService.Interface
{
    public interface IAltService
    {
        public List<AltData> GetBySuperClassGUID(IData data);
    }
}

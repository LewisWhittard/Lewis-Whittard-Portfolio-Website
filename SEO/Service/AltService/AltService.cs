using Infrastructure.Models.Data.Interface;
using SEO.Models.Alt;
using SEO.Service.AltService.Interface;

namespace SEO.Service.AltService
{
    public class AltService : IAltService
    {
        public List<AltData> GetBySuperClassGUID(string superClassGUID, bool includeInactive)
        {
            throw new NotImplementedException();
        }
    }
}

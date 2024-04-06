using SEO.Models.Alt;
using SEO.Models.Alt.Interface;
using SEO.Service.AltService.Interface;

namespace SEO.Service.AltService
{
    public class AltService : IAltService
    {
        public List<IAltData> GetByPageName(string PageName)
        {
            return new List<IAltData>();
        }
    }
}

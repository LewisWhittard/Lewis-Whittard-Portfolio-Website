using SEO.Models.Alt;
using SEO.Models.Alt.Interface;
using SEO.Service.AltService.Interface;

namespace SEO.Service.AltService
{
    public class AltService : IAltService
    {
        public List<IAltData> Get(string PageName)
        {
            return new List<IAltData>();
        }
    }
}

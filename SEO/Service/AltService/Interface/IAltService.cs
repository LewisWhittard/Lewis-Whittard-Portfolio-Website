using SEO.Models.Alt;
using SEO.Models.Alt.Interface;

namespace SEO.Service.AltService.Interface
{
    public interface IAltService
    {
        public List<IAltData> Get(string PageName);
    }
}

using SEO.Models.Alt.Interface;

namespace SEO.Service.AltService.Interface
{
    public interface IAltService
    {
        public List<IAltData> GetBySuperClassGUID(string superClassGUID, bool includeInactive);
    }
}

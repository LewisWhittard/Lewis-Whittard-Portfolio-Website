using SEO.Model.Alt;

namespace SEO.Service.AltService.Interface
{
    public interface IAltService
    {
        public AltData GetByUIId(string uIId, bool includeInactive);
    }
}

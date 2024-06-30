using SEO.Model.Alt;

namespace SEO.Service.AltService.Interface
{
    public interface IAltService
    {
        public AltData GetBySuperClassUIID(string superClassUIID, bool includeInactive);
    }
}

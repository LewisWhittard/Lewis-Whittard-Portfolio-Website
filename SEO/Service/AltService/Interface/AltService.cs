using SEO.Model.Alt;

namespace SEO.Service.AltService.Interface
{
    public interface IAltService
    {
        public AltData GetBySuperClassGUID(string superClassGUID, bool includeInactive);
    }
}

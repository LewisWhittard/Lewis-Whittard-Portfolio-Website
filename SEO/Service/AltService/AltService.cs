using SEO.Model.Alt;
using SEO.Repository.AltRepository.Interface;
using SEO.Service.AltService.Interface;

namespace SEO.Service.AltService
{
    public class AltService : IAltService
    {
        private readonly IAltRepository _altRepository;

        public AltService(IAltRepository altRepository)
        {
            _altRepository = altRepository;
        }

        public AltData GetBySuperClassUIID(string superClassUIID, bool includeInactive)
        {

            AltData data = null;

            if (includeInactive == true) 
            {
                data = _altRepository.GetAltDatas().Where(x => x.SuperClassUIID == superClassUIID && !x.Deleted).FirstOrDefault();
            }
            else
            {
                data = _altRepository.GetAltDatas().Where(x => x.SuperClassUIID == superClassUIID && !x.Deleted && !x.Inactive).FirstOrDefault();
            }

            return data;
        }
    }
}

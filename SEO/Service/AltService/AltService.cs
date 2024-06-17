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

        public AltData GetBySuperClassGUID(string superClassGUID, bool includeInactive)
        {

            AltData data = null;

            if (includeInactive == true) 
            {
                data = _altRepository.GetAltDatas().Where(x => x.SuperClassGUID == superClassGUID && !x.Deleted).FirstOrDefault();
            }
            else
            {
                data = _altRepository.GetAltDatas().Where(x => x.SuperClassGUID == superClassGUID && !x.Deleted && !x.Inactive).FirstOrDefault();
            }

            return data;
        }
    }
}

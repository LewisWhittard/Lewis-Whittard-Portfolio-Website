using SEO.Models.Alt;
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

        public List<AltData> GetBySuperClassGUID(string superClassGUID, bool includeInactive)
        {
            if (includeInactive == true) 
            {
                return _altRepository.GetAltDatas().Where(x => x.SuperClassGUID == superClassGUID).ToList();
            }
            else
            {
                return _altRepository.GetAltDatas().Where(x => x.SuperClassGUID == superClassGUID && !x.Inactive).ToList();
            }
        }
    }
}

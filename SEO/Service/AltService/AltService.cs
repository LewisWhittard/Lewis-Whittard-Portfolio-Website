using SEO.Models.Alt;
using SEO.Models.Alt.Interface;
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

        public List<IAltData> GetBySuperClassGUID(string superClassGUID, bool includeInactive)
        {
            List<IAltData> result = new List<IAltData>();

            if (includeInactive == true) 
            {
                var data = _altRepository.GetAltDatas().Where(x => x.SuperClassGUID == superClassGUID && !x.Deleted).ToList();
                result.AddRange(data);
            }
            else
            {
                var data = _altRepository.GetAltDatas().Where(x => x.SuperClassGUID == superClassGUID && !x.Deleted && !x.Inactive).ToList();
                result.AddRange(data);
            }

            return result;
        }

        List<AltData> IAltService.GetBySuperClassGUID(string superClassGUID, bool includeInactive)
        {
            throw new NotImplementedException();
        }
    }
}

using SEO.Models.Meta.Interface;

namespace SEO.Repository.MetaRepository.Interface
{
    public interface IMetaRepository
    {
        public List<MetaData> GetMetaDatas();
    }
}

using EditableHTMLAttributes.Repository.Tag.Tag.Interface;

namespace EditableHTMLAttributes.Service.Tag
{
    public class TagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public Model.Tag GetByUIId(string uIId, bool includeInactive)
        {
            if (includeInactive == false)
            {
                return _tagRepository.GetByUIId(uIId).Where(x => x.Inactive == false && x.Deleted == false).FirstOrDefault();
            }
            else
            {
                return _tagRepository.GetByUIId(uIId).Where(x => x.Deleted == false).FirstOrDefault();
            }
        }
    }
}

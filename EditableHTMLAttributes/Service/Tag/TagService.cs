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

        public Model.Tag GetByUIId(int id, bool inactive)
        {
            if (inactive == false)
            {
                return _tagRepository.GetByUIId(id).Where(x => x.Inactive == false).FirstOrDefault();
            }
            else
            {
                return _tagRepository.GetByUIId(id).FirstOrDefault();
            }
        }
    }
}

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

        public List<Model.Tag> GetByInformationBlockId(int id, bool inactive)
        {
            if (inactive == false)
            {
                return _tagRepository.GetByInformationBlockId(id).Where(x => x.Inactive == false).ToList();
            }
            else
            {
                return _tagRepository.GetByInformationBlockId(id);
            }
        }
    }
}

using EditableHTMLAttributes.Repository.Tag.Tag.Interface;

namespace EditableHTMLAttributes.Repository.Tag.Tag
{
    internal class TagRepository : ITagRepository
    {
        private List<Model.Tag> _tag;

        public List<Model.Tag> GetByUIId(int id)
        {
            return _tag.Where(x => x.UIId == id).ToList();
        }
    }
}

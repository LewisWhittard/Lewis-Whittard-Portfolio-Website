using EditableHTMLAttributes.Model.Interface;
using EditableHTMLAttributes.Repository.Tag.Tag.Interface;

namespace EditableHTMLAttributes.Repository.Tag.Tag
{
    internal class TagRepository : ITagRepository
    {
        private List<Model.Tag> _tag;

        public TagRepository()
        {
            _tag.Add(new Model.Tag(0,TagType.Article,false,false,3));
            _tag.Add(new Model.Tag(1, TagType.Article, true, true, 2));
            _tag.Add(new Model.Tag(2, TagType.Article, true, false, 1));
            _tag.Add(new Model.Tag(3, TagType.Article, false, true, 0));
        }

        public List<Model.Tag> GetByUIId(int id)
        {
            return _tag.Where(x => x.UIId == id).ToList();
        }
    }
}

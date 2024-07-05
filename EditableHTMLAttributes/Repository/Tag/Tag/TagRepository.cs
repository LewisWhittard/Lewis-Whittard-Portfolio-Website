using EditableHTMLAttributes.Model.Interface;
using EditableHTMLAttributes.Repository.Tag.Tag.Interface;

namespace EditableHTMLAttributes.Repository.Tag
{
    public class MockTagRepository : ITagRepository
    {
        private List<Model.Tag> _tag;

        public MockTagRepository()
        {
            _tag = new List<Model.Tag>();
            _tag.Add(new Model.Tag(0,TagType.Article,false,false,"First"));
            _tag.Add(new Model.Tag(1, TagType.Section, false, false, "Second"));
            _tag.Add(new Model.Tag(3, TagType.Article, false, true, "IncludeInactive"));
            _tag.Add(new Model.Tag(4, TagType.Article, false, true, "ExcludeInactive"));
            _tag.Add(new Model.Tag(5, TagType.Article, true, false, "Deleted"));
        }

        public List<Model.Tag> GetByUIId(string UUId)
        {
            return _tag.Where(x => x.UIId == UUId).ToList();
        }
    }
}

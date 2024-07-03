using EditableHTMLAttributes.Model;

namespace EditableHTMLAttributes.Repository.Tag.Tag.Interface
{
    public interface ITagRepository
    {
        public List<Model.Tag> GetByInformationBlockId(int id);
    }
}

namespace EditableHTMLAttributes.Repository.Tag.Tag.Interface
{
    public interface ITagRepository
    {
        public List<Model.Tag> GetByUIId(string uIID);
    }
}

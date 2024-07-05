namespace EditableHTMLAttributes.Service.Tag.Interface
{
    public interface ITagService
    {
        public List<Model.Tag> GetByInformationBlockId(int id, bool inactive);
    }
}

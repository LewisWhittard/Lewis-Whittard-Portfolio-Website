namespace EditableHTMLAttributes.Model.Interface
{
    public interface ITag
    {
        int Id { get; }
        TagType Type { get; }
        bool Deleted { get; }
        bool Inactive { get; }
        string UIId { get; }
    }
}

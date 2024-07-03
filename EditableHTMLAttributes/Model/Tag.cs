using EditableHTMLAttributes.Model.Interface;

namespace EditableHTMLAttributes.Model
{
    public class Tag : ITag
    {
        public int Id { get; private set; }
        public TagType Type { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }

        public Tag()
        {
            
        }

        public Tag(int id, TagType type, bool deleted, bool inactive)
        {
            Id = id;
            Type = type;
            Deleted = deleted;
            Inactive = inactive;
        }
    }
}

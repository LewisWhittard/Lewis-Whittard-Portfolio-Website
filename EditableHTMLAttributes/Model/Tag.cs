using EditableHTMLAttributes.Model.Interface;

namespace EditableHTMLAttributes.Model
{
    public class Tag : ITag
    {
        public int Id { get; private set; }
        public TagType Type { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }

        private readonly int _id;
        private readonly TagType _type;
        private readonly bool _deleted;
        private readonly bool _inactive;

        public Tag()
        {
            
        }

        public Tag(int Id, TagType type, bool Deleted, bool Inactive)
        {
            _id = Id;
            _type = type;
            _deleted = Deleted;
            _inactive = Inactive;
            Id = _id;
            Type = _type;
            Deleted = _deleted;
            Inactive = _inactive;
        }
    }
}

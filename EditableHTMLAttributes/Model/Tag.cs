using EditableHTMLAttributes.Model.Interface;
using Infrastructure.Models.Data.Interface;

namespace EditableHTMLAttributes.Model
{
    public class Tag : ITag, IData
    {
        public int Id { get; private set; }
        public TagType Type { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public string UIId { get; private set; }
        public UIConcrete? UIConcreteType { get; private set; }
        public int? DisplayOrder { get; private set; }

        public Tag()
        {
            
        }

        public Tag(int id, TagType type, bool deleted, bool inactive, string uIId)
        {
            Id = id;
            Type = type;
            Deleted = deleted;
            Inactive = inactive;
            UIId = uIId;
        }
    }
}

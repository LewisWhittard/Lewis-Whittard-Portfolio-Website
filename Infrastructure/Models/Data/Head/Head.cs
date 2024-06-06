using Infrastructure.Models.Data.Head.Interface;
using Infrastructure.Models.Data.Interface;

namespace Infrastructure.Models.Data.Head
{
    public class Head : IData, IHead
    {
        public int Id { get; private set; }
        public int? DisplayOrder { get; private set; }
        public string? GUID { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public UIConcrete? UIConcreteType { get; private set; }
        public string Title { get; private set; }

        public Head(int id, int? displayOrder, bool deleted, bool inactive, string title)
        {
            Id = id;
            DisplayOrder = displayOrder;
            GUID = null;
            Deleted = deleted;
            Inactive = inactive;
            UIConcreteType = UIConcrete.Head;
            Title = title;
        }

        public Head()
        {
            UIConcreteType = UIConcrete.Head;
        }
    }
}

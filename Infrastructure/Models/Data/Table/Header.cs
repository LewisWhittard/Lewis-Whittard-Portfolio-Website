using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Table.Interfaces;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Table
{
    public class Header : IData, IHeader
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public int? DisplayOrder { get; set; }
        public int TableID { get; set; }
        public string Value { get; set; }
        public string GUID { get; set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; set; }

        public Header()
        {
            UIConcreteType = UIConcrete.Header;
        }

        public Header(int id, bool deleted, bool inactive, int displayOrder, int tableID, string value, string gUID)
        {
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            DisplayOrder = displayOrder;
            TableID = tableID;
            Value = value;
            GUID = gUID;
            UIConcreteType = UIConcrete.Header;
        }
    }
}

using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Table.Interfaces;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Table
{
    public class Header : IData, IHeader
    {
        public int Id { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public int? DisplayOrder { get; private set; }
        public int TableID { get; private set; }
        public string Value { get; private set; }
        public string UIID { get; private set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; private set; }

        public Header()
        {
            UIConcreteType = UIConcrete.Header;
        }

        public Header(int id, bool deleted, bool inactive, int displayOrder, int tableID, string value, string uIId)
        {
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            DisplayOrder = displayOrder;
            TableID = tableID;
            Value = value;
            UIID = uIId;
            UIConcreteType = UIConcrete.Header;
        }
    }
}

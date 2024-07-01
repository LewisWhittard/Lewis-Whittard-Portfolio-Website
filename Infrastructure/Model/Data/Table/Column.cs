using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Table.Interfaces;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Table
{
    public class Column : IColumn, IData
    {
        public int Id { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public string Value { get; private set; }
        public int? DisplayOrder { get; private set; }
        public int TableID { get; private set; }
        public string UIId { get; private set; }
        public int RowId { get; private set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; private set; }

        public Column()
        {
            UIConcreteType = UIConcrete.Column;
        }

        public Column(int id, bool deleted, bool inactive, string value, int displayOrder, int tableID, string uIId, int rowId)
        {
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            Value = value;
            DisplayOrder = displayOrder;
            TableID = tableID;
            UIId = uIId;
            UIConcreteType = UIConcrete.Column;
            RowId = rowId;
        }
    }
}

using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Table.Interfaces;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Table
{
    public class Column : IColumn, IData
    {

        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public string Value { get; set; }
        public int DisplayOrder { get; set; }
        public int TableID { get; set; }
        public string GUID { get; set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; set; }

        public Column()
        {

        }

        public Column(int id, bool deleted, bool inactive, string value, int displayOrder, int rowID, int tableID)
        {
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            Value = value;
            DisplayOrder = displayOrder;
            TableID = tableID;
        }
    }
}

using Infrastructure.Models.Data.Table.Interfaces;
using Infrastructure.Models.DataStandards.Interface;

namespace Infrastructure.Models.Data.Table
{
    public class Column : IColumn, IData
    {

        public int id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public string Value { get; set; }
        public int DisplayOrder { get; set; }
        public int RowID { get; set; }
        public int TableID { get; set; }

        public Column()
        {
            id = 0;
        }

        public Column(int iD, bool deleted, bool inactive, string value, int displayOrder, int rowID, int tableID)
        {
            id = id;
            Deleted = deleted;
            Inactive = inactive;
            Value = value;
            DisplayOrder = displayOrder;
            RowID = rowID;
            TableID = tableID;
        }
    }
}

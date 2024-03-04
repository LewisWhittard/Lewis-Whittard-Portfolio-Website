using Infrastructure.Models.Data.Table.Column.Interface;
using Infrastructure.Models.DataStandards.Interface;

namespace Infrastructure.Models.Data.Table.Column
{
    public class Column : IColumn, IData
    {

        public int ID { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public string Value { get; set; }
        public int DisplayOrder { get; set; }
        public int RowID { get; set; }
        public int TableID { get; set; }

        public Column()
        {
            ID = 0;
        }

        public Column(int iD, bool deleted, bool inactive, string value, int displayOrder, int rowID, int tableID)
        {
            ID = ID;
            Deleted = deleted;
            Inactive = inactive;
            Value = value;
            DisplayOrder = displayOrder;
            RowID = rowID;
            TableID = tableID;
        }
    }
}

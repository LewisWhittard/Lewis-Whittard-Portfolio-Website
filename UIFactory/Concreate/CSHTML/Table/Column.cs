using UIFactory.Concreate.CSHTML.Interface;
using UIFactory.Concreate.CSHTML.Table.Interfaces;

namespace UIFactory.Concreate.CSHTML.Table
{
    public class Column : IColumn, IHTML
    {

        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public string Value { get; set; }
        public int DisplayOrder { get; set; }
        public int RowID { get; set; }
        public int TableID { get; set; }

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
            RowID = rowID;
            TableID = tableID;
        }
    }
}

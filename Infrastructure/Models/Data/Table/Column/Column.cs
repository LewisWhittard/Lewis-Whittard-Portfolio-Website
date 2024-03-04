using Infrastructure.Models.Data.Table.Column.Interface;
using Infrastructure.Models.DataStandards.Interface;

namespace Infrastructure.Models.Data.Table.Column
{
    public class Column : IColumn, IData
    {

        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Inactive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DisplayOrder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int RowID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int TableID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

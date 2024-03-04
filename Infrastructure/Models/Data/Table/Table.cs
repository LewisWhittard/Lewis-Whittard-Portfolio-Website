using Infrastructure.Models.Data.Table.Interface;
using Infrastructure.Models.DataStandards.Interface;

namespace Infrastructure.Models.Data.Table
{
    public class Table : IData, ITable
    {
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Inactive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DisplayOrder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Header.Header> Headers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Column.Column> Columns { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Table()
        {
            
        }

        public Table(int iD, bool deleted, bool inactive, int displayOrder, List<Header.Header> headers, List<Column.Column> columns)
        {
            iD = ID;
            Deleted = deleted;
            Inactive = inactive;
            DisplayOrder = displayOrder;
            Headers = headers;
            Columns = columns;
        }
    }
}

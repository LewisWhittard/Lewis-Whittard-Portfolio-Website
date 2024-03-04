using Infrastructure.Models.Data.Table.Interface;
using Infrastructure.Models.DataStandards.Interface;

namespace Infrastructure.Models.Data.Table
{
    public class Table : IData, ITable
    {
        public int ID { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public int DisplayOrder { get; set; }
        public List<Header.Header> Headers { get; set; }
        public List<Column.Column> Columns { get; set; }
        public string WebPage { get; set; }

        public Table()
        {
            
        }

        public Table(int iD, bool deleted, bool inactive, int displayOrder, List<Header.Header> headers, List<Column.Column> columns, string webpage)
        {
            iD = ID;
            Deleted = deleted;
            Inactive = inactive;
            DisplayOrder = displayOrder;
            Headers = headers;
            Columns = columns;
            WebPage = webpage;
        }
    }
}

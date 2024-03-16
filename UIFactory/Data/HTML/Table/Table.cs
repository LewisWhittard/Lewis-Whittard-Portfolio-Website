using UIFactory.Data.HTML.Interface;
using UIFactory.Data.HTML.Table.Interfaces;

namespace UIFactory.Data.HTML.Table
{
    public class Table : IData, ITable
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public List<Header> Headers { get; set; }
        public List<Column> Columns { get; set; }
        public string WebPage { get; set; }
        public int DisplayOrder { get; set; }

        public Table()
        {

        }

        public Table(int id, bool deleted, bool inactive, int displayOrder, List<Header> headers, List<Column> columns, string webpage)
        {
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            Headers = headers;
            Columns = columns;
            WebPage = webpage;
        }
    }
}

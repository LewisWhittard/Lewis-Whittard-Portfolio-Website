using UIFactory.Concreate.CSHTML.Interface;
using UIFactory.Concreate.CSHTML.Table.Interfaces;

namespace UIFactory.Concreate.CSHTML.Table
{
    public class Table : ITable, IHTML, IJsonLD
    {
        public int Id { get; set; }
        public List<Header> Headers { get; set; }
        public List<Column> Columns { get; set; }
        public string WebPage { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }

        public Table()
        {

        }

        public Table(int id, bool deleted, bool inactive, int displayOrder, List<Header> headers, List<Column> columns, string webpage)
        {
            Id = id;
            Headers = headers;
            Columns = columns;
            WebPage = webpage;
        }
    }
}

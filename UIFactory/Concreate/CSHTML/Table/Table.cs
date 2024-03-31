using UIFactory.Concreate.CSHTML.Interface;
using UIFactory.Concreate.CSHTML.Table.Interfaces;

namespace UIFactory.Concreate.CSHTML.Table
{
    public class Table : ITable, ICSHTML, IJsonLD
    {
        public int Id { get; set; }
        public List<Header> Headers { get; set; }
        public List<Column> Columns { get; set; }
        public string WebPage { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }

        public Table(Infrastructure.Models.Data.Table.Table table)
        {
            Id = 0;
            foreach (var item in table.Headers)
            {
                Header table = new Header(item);
            }
            foreach (var item in table.Columns)
            {
                Column table = new Column(item);
            }
        }
    }
}

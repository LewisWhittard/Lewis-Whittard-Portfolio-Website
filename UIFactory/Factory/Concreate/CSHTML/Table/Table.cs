using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.Concreate.CSHTML.Interface;
using UIFactory.Factory.Concreate.CSHTML.Table.Interfaces;

namespace UIFactory.Factory.Concreate.CSHTML.Table
{
    public class Table : ITable, ICSHTML, IJsonLD
    {
        public int Id { get; set; }
        public List<Header> Headers { get; set; }
        public List<Column> Columns { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
        public UIPartial? UIPartialType { get; set; }
        private readonly Infrastructure.Models.Data.Table.Table _table;

        public Table(Infrastructure.Models.Data.Table.Table table)
        {
            _table = table;
            Id = _table.Id;
            foreach (var item in _table.Headers)
            {
                Header header = new Header(item);
                Headers.Add(header);
            }
            foreach (var item in _table.Columns)
            {
                Column column = new Column(item);
                Columns.Add(column);
            }
            DisplayOrder = _table.DisplayOrder;
            UIPartialType = UIPartial.Table;
        }
    }
}

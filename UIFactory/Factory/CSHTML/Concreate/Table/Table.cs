using UIFactory.Factory.CSHTML.Concreate.Interface;
using UIFactory.Factory.CSHTML.Concreate.Table.Interfaces;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concreate.Table
{
    public class Table : ITable, ICSHTML, IJsonLD, IUI
    {
        public List<Header> Headers { get; set; }
        public List<Column> Columns { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
        public UIPartial? UIPartialType { get; set; }
        private readonly Infrastructure.Models.Data.Table.Table _table;

        public Table(Infrastructure.Models.Data.Table.Table table)
        {
            _table = table;
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

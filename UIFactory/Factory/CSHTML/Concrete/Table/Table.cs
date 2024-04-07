using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.CSHTML.Concrete.Table.Interfaces;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.Table
{
    public class Table : ITable, ICSHTML, IJsonLD, IUI
    {
        public List<Header> Headers { get; set; }
        public List<Column> Columns { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
        public UI? UIType { get; set; }
        public string GUID { get; set; }

        private readonly Infrastructure.Models.Data.Table.Table _table;

        public Table(Infrastructure.Models.Data.Table.Table table)
        {
            _table = table;
            GUID = _table.GUID;
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
            UIType = UI.Table;
        }
    }
}

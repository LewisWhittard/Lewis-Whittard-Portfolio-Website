using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.CSHTML.Concrete.Table.Interfaces;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.Table
{
    public class Table : ITable, ICSHTML, IJsonLD, IUI
    {
        public string Title { get; private set; }
        public List<Header> Headers { get; private set; }
        public List<List<Column>> Columns { get; private set; }
        public int? DisplayOrder { get; private set; }
        public List<string> JsonLDValues { get; private set; }
        public UI? UIType { get; private set; }
        public string GUID { get; private set; }

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
                List<Column> columnRow = new List<Column>();
                foreach (var item2 in item)
                {
                    Column column = new Column(item2);
                    columnRow.Add(column);
                }
                Columns.Add(columnRow);
            }
            DisplayOrder = _table.DisplayOrder;
            UIType = UI.Table;
        }
    }
}

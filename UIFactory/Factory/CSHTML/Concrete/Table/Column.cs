using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.CSHTML.Concrete.Table.Interfaces;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.Table
{
    public class Column : IColumn, ICSHTML, IUI
    {
        public string Value { get; private set; }
        public int? DisplayOrder { get; private set; }
        public int TableID { get; private set; }
        public UI? UIType { get; private set; }
        public string GUID { get; private set; }

        private readonly Infrastructure.Models.Data.Table.Column _column;

        public Column(Infrastructure.Models.Data.Table.Column column)
        {
            _column = column;
            Value = _column.Value;
            DisplayOrder = _column.DisplayOrder;
            TableID = _column.TableID;
            GUID = _column.GUID;
        }
    }
}

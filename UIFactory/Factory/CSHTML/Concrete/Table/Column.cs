using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.CSHTML.Concrete.Table.Interfaces;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.Table
{
    public class Column : IColumn, ICSHTML, IUI
    {
        public string Value { get; set; }
        public int DisplayOrder { get; set; }
        public int RowID { get; set; }
        public int TableID { get; set; }
        public UI? UIType { get; set; }
        public string GUID { get; set; }

        private readonly Infrastructure.Models.Data.Table.Column _column;

        public Column(Infrastructure.Models.Data.Table.Column column)
        {
            _column = column;
            Value = _column.Value;
            DisplayOrder = _column.DisplayOrder;
            RowID = _column.RowID;
            TableID = _column.TableID;
            GUID = _column.GUID;
        }
    }
}

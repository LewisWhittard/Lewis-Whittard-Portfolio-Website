using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.Concreate.CSHTML.Interface;
using UIFactory.Factory.Concreate.CSHTML.Table.Interfaces;

namespace UIFactory.Factory.Concreate.CSHTML.Table
{
    public class Column : IColumn, ICSHTML
    {
        public string Value { get; set; }
        public int DisplayOrder { get; set; }
        public int RowID { get; set; }
        public int TableID { get; set; }
        public UIPartial? UIPartialType { get; set; }
        private readonly Infrastructure.Models.Data.Table.Column _column;

        public Column(Infrastructure.Models.Data.Table.Column column)
        {
            _column = column;
            Value = _column.Value;
            DisplayOrder = _column.DisplayOrder;
            RowID = _column.RowID;
            TableID = _column.TableID;
        }
    }
}

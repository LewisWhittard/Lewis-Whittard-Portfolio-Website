using UIFactory.Factory.Concrete.Table.Interface;

namespace UIFactory.Factory.Concrete.Table
{
    public class Column : IColumn
    {
        public Infrastructure.Models.Data.Table.Column ColumnData { get; private set; }
    }
}

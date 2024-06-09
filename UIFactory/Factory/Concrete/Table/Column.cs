using UIFactory.Factory.Concrete.Table.Interface;

namespace UIFactory.Factory.Concrete.Table
{
    public class Column : IColumn
    {
        public Infrastructure.Models.Data.Table.Column ColumnData { get; private set; }

        private readonly Infrastructure.Models.Data.Table.Column _column;

        public Column(Infrastructure.Models.Data.Table.Column column)
        {
            _column = column;
            ColumnData = _column;
        }
    }
}

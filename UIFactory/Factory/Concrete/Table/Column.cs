using Infrastructure.Models.Data.Table;
using UIFactory.Factory.Concrete.Table.Interface;

namespace UIFactory.Factory.Concrete.Table
{
    public class Columns : IColumns
    {
        public List<List<Infrastructure.Models.Data.Table.Column>> ColumnDatas { get; private set; }

        private readonly List<List<Infrastructure.Models.Data.Table.Column>> _columns;

        public Columns(List<List<Infrastructure.Models.Data.Table.Column>> columns)
        {
            _columns = columns;
            ColumnDatas = _columns;
        }
    }
}

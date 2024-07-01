using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Concrete.Table.Interface;

namespace UIFactory.Factory.Concrete.Table
{
    public class Column : IColumn, IConcreteUI
    {
        public Infrastructure.Models.Data.Table.Column ColumnData { get; private set; }
        public int? DisplayOrder { get; private set; }
        public UIConcrete UIConcreteType { get; private set; }

        public Column(Infrastructure.Models.Data.Table.Column column)
        {
            ColumnData = column;
            DisplayOrder = (int)column.DisplayOrder;
            UIConcreteType = (UIConcrete)column.UIConcreteType;
        }
    }
}

using UIFactory.Factory.Concrete.Table;

namespace UIFactory.Factory.Concrete.Table.Interfaces
{
    public interface ITable
    {
        List<Header> Headers { get; }
        List<List<Column>> Columns { get; }
    }
}

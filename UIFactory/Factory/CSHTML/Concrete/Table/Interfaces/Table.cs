namespace UIFactory.Factory.CSHTML.Concrete.Table.Interfaces
{
    public interface ITable
    {
        List<Header> Headers { get; }
        List<List<Column>> Columns { get; }
    }
}

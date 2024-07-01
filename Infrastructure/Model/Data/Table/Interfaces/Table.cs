namespace Infrastructure.Models.Data.Table.Interfaces
{
    public interface ITable
    {
        string Title { get; }
        List<Header> Headers { get; }
        List<List<Column>> Columns { get; }
        int PageId { get; }
    }
}

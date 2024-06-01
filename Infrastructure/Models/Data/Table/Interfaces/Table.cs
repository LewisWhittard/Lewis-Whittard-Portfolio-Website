namespace Infrastructure.Models.Data.Table.Interfaces
{
    public interface ITable
    {
        public string Title { get; set; }
        public List<Header> Headers { get; set; }
        public List<List<Column>> Columns { get; set; }
        public int PageId { get; set; }
    }
}

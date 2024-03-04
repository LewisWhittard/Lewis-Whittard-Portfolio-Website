namespace Infrastructure.Models.Data.Table.Interface
{
    public interface ITable
    {
        public List<Header.Header> Headers { get; set; }
        public List<Column.Column> Columns { get; set; }
        public int DisplayOrder { get; set; }
    }
}

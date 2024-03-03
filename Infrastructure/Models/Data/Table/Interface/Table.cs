namespace Infrastructure.Models.Data.Table.Interface
{
    public interface ITable
    {
        public List<Header.Header> Headers { get; set; }
        public List<Row.Row> rows { get; set; }
        public int DisplayOrder { get; set; }
    }
}

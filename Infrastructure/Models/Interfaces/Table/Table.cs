using Infrastructure.Models.Data.Table;

namespace Infrastructure.Models.Interfaces.Table
{
    public interface ITable
    {
        public List<Header> Headers { get; set; }
        public List<Column> Columns { get; set; }
    }
}

using UIFactory.Data.HTML.Table;

namespace UIFactory.Data.HTML.Table.Interfaces
{
    public interface ITable
    {
        public List<Header> Headers { get; set; }
        public List<Column> Columns { get; set; }
        public int DisplayOrder { get; set; }
    }
}

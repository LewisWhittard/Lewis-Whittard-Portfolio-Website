using UIFactory.Factory.CSHTML.Concreate.Table;

namespace UIFactory.Factory.CSHTML.Concreate.Table.Interfaces
{
    public interface ITable
    {
        public List<Header> Headers { get; set; }
        public List<Column> Columns { get; set; }
        public int DisplayOrder { get; set; }
    }
}

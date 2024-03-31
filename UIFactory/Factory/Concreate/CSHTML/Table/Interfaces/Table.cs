using UIFactory.Factory.Concreate.CSHTML.Table;

namespace UIFactory.Factory.Concreate.CSHTML.Table.Interfaces
{
    public interface ITable
    {
        public List<Header> Headers { get; set; }
        public List<Column> Columns { get; set; }
        public int DisplayOrder { get; set; }
    }
}

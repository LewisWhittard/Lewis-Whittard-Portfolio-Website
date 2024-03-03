using Infrastructure.Models.DataStandards.Interface;

namespace Infrastructure.Models.Data.Table.Row
{
    public class Row : IData
    {
        public int TableID { get; set; }
        public int DisplayOrder { get; set; }
        public int ID { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        List<Column.Column> Columns { get; set; }

    }
}
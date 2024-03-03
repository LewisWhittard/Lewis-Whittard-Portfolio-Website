using Infrastructure.Models.Data.Table.Interface;
using Infrastructure.Models.DataStandards.Interface;

namespace Infrastructure.Models.Data.Table
{
    public class Table : IData, ITable
    {
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Inactive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DisplayOrder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Header.Header> Headers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Row.Row> rows { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

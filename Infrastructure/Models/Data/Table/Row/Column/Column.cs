using Infrastructure.Models.Data.Table.Row.Column.Interface;
using Infrastructure.Models.DataStandards.Interface;

namespace Infrastructure.Models.Data.Table.Row.Column
{
    public class Column : IColumn, IData
    {

        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Inactive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DisplayOrder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

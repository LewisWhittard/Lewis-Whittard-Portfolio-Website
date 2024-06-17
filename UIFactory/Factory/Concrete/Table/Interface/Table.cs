using SEO.Models.JsonLD;

namespace UIFactory.Factory.Concrete.Table.Interface
{
    public interface ITable
    {
        Infrastructure.Models.Data.Table.Table TableData { get; }
        List<Header> Headers { get; }
        List<List<Column>> Columns { get; }
        List<JsonLDData> JsonLDDatas { get; }
    }
}

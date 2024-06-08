namespace UIFactory.Factory.Concrete.Table.Interface
{
    public interface ITable
    {
        Infrastructure.Models.Data.Table.Table TableData { get; }
        List<SEO.Models.JsonLD.JsonLDData> JsonLDs { get; }
    }
}

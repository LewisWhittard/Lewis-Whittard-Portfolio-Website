namespace UIFactory.Factory.Concrete.Table.Interface
{
    public interface ITable
    {
        Infrastructure.Models.Data.Table.Table TableData { get; }
        List<Headers> Headers { get; }
        List<List<Columns>> Columns { get; }
        SEO.Models.JsonLD.Interface.IJsonLDData JsonLD { get; }
    }
}

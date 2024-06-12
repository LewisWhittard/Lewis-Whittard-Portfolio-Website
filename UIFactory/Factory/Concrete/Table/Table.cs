using SEO.Models.JsonLD.Interface;
using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Concrete.Table.Interface;

namespace UIFactory.Factory.Concrete.Table
{
    public class Table : ITable, IConcrete
    {
        public Infrastructure.Models.Data.Table.Table TableData { get; private set; }

        public List<Headers> Headers { get; private set; }

        public List<List<Column>> Columns { get; private set; }

        public List<IJsonLDData> JsonLD { get; private set; }
    }
}

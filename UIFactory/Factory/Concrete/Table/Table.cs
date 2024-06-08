using SEO.Models.JsonLD;
using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Concrete.Table.Interface;

namespace UIFactory.Factory.Concrete.Table
{
    internal class Table : ITable, IConcrete
    {
        public Infrastructure.Models.Data.Table.Table TableData { get; private set; }
        public List<JsonLDData> JsonLDs { get; private set; }

        //private read only JsonLDservice and Table Data
        private readonly SEO.Service.JsonLDService.JsonLDService _jsonLDService;
        private readonly Infrastructure.Models.Data.Table.Table _table;

        //ctor with JsonLDService and Table Data
        public Table(SEO.Service.JsonLDService.JsonLDService jsonLDService, Infrastructure.Models.Data.Table.Table table)
        {
            _jsonLDService = jsonLDService;
            _table = table;
            TableData = _table;
            SetJsonLD();
        }

        public void SetJsonLD()
        {
            if (JsonLDs != null)
            {
                JsonLDs = _jsonLDService.GetBySuperClassGUID(TableData.GUID,false);
            }
            else
            {
                JsonLDs = null;
            }
        }

    }
}

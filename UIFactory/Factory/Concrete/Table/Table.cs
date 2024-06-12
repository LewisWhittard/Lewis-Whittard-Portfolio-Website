using SEO.Models.JsonLD;
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

        public List<JsonLDData> JsonLD { get; private set; }

        private readonly Infrastructure.Models.Data.Table.Table _tableData;
        private readonly SEO.Service.JsonLDService.JsonLDService _jsonLDService;


        public Table(Infrastructure.Models.Data.Table.Table tableData, SEO.Service.JsonLDService.JsonLDService jsonLDService)
        {
            _tableData = tableData;
            _jsonLDService = jsonLDService;
            JsonLD = _jsonLDService.GetBySuperClassGUID(_tableData.GUID,false);
            TableData = _tableData;
            SetHeaders();
            SetColumns();
        }


        public void SetHeaders()
        {
            Headers = new List<Headers>();
            foreach (var header in TableData.Headers)
            {
                Headers.Add(new Headers(header));
            }
        }

        public void SetColumns()
        {
            Columns = new List<List<Column>>();
            foreach (var column in TableData.Columns)
            {
                var columnList = new List<Column>();
                foreach (var col in column)
                {
                    columnList.Add(new Column(col));
                }
                Columns.Add(columnList);
            }
        }

    }
}

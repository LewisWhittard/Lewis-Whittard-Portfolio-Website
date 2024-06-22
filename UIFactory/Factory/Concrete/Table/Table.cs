using Infrastructure.Models.Data.Interface;
using SEO.Model.JsonLD;
using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Concrete.Table.Interface;

namespace UIFactory.Factory.Concrete.Table
{
    public class Table : ITable, IConcreteUI
    {
        public Infrastructure.Models.Data.Table.Table TableData { get; private set; }
        public List<Header> Headers { get; private set; }
        public List<List<Column>> Columns { get; private set; }
        public List<JsonLDData>? JsonLDDatas { get; private set; }
        public int? DisplayOrder { get; private set; }
        public UIConcrete UIConcreteType { get; private set; }

        private readonly Infrastructure.Models.Data.Table.Table _tableData;
        private readonly SEO.Service.JsonLDService.JsonLDService? _jsonLDService;


        public Table(Infrastructure.Models.Data.Table.Table tableData, SEO.Service.JsonLDService.JsonLDService? jsonLDService)
        {
            _tableData = tableData;
            _jsonLDService = jsonLDService;
            SetJsonLD();
            TableData = _tableData;
            SetHeaders();
            SetColumns();
            DisplayOrder = (int)_tableData.DisplayOrder;
            UIConcreteType = (UIConcrete)_tableData.UIConcreteType;
        }


        //set jsonld
        public void SetJsonLD()
        {
            if (_jsonLDService != null)
            {
                JsonLDDatas = _jsonLDService.GetBySuperClassGUID(_tableData.GUID, false);
            }
            else
            {
                JsonLDDatas = null;
            }

        }

        public void SetHeaders()
        {
            Headers = new List<Header>();
            foreach (var header in TableData.Headers)
            {
                Headers.Add(new Header(header));
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

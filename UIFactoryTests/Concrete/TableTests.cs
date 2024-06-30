using Infrastructure.Models.Data.Table;
using SEO.Repository.JsonLDRepositoryRepository;
using SEO.Service.JsonLDService;

namespace UIFactoryTests.Concrete
{
    public class TableTests
    {
        private List<Table> _table;
        private JsonLDService jsonLDService;

        public void SetUp()
        {
            jsonLDService = new JsonLDService(new MockJsonLDRepository());
            _table = new List<Table>();
            List<Header> headers0 = new List<Header>();
            List<List<Column>> columnsList0 = new List<List<Column>>();

            headers0.Add(new Header(0, false, false, 0, 0, "Header0", "Header00UIID"));
            headers0.Add(new Header(1, false, false, 1, 0, "Header1", "Header01UIID"));
            List<Column> columns0 = new List<Column>();
            List<Column> columns1 = new List<Column>();
            columns0.Add(new Column(0, false, false, "Column0", 0, 0, "Column00UIID", 0));
            columns0.Add(new Column(1, false, false, "Column1", 1, 0, "Column01UIID", 0));
            columns1.Add(new Column(2, false, false, "Column2", 0, 0, "Column02UIID", 1));
            columns1.Add(new Column(3, false, false, "Column3", 1, 0, "Column03UIID", 1));
            columnsList0.Add(columns0);
            columnsList0.Add(columns1);

            List<Header> headers1 = new List<Header>();
            List<List<Column>> columnsList1 = new List<List<Column>>();

            headers1.Add(new Header(2, false, false, 0, 1, "Header2", "Header12UIID"));
            headers1.Add(new Header(3, false, false, 1, 1, "Header3", "Header13UIID"));
            List<Column> columns2 = new List<Column>();
            List<Column> columns3 = new List<Column>();
            columns2.Add(new Column(4, false, false, "Column4", 0, 1, "Column10UIID", 2));
            columns2.Add(new Column(5, false, false, "Column5", 1, 1, "Column11UIID", 2));
            columns3.Add(new Column(6, false, false, "Column6", 0, 1, "Column12UIID", 3));

            List<Header> header2 = new List<Header>();
            List<List<Column>> columnsList2 = new List<List<Column>>();

            header2.Add(new Header(4, false, false, 0, 2, "Header4", "Header24UIID"));
            header2.Add(new Header(5, false, false, 1, 2, "Header5", "Header25UIID"));

            List<Column> columns4 = new List<Column>();
            List<Column> columns5 = new List<Column>();
            columns4.Add(new Column(7, false, false, "Column7", 0, 2, "Column20UIID", 4));
            columns4.Add(new Column(8, false, false, "Column8", 1, 2, "Column21UIID", 4));
            columns5.Add(new Column(9, false, false, "Column9", 0, 2, "Column22UIID", 5));
            columns5.Add(new Column(10, false, false, "Column10", 1, 2, "Column23UIID", 5));
            columnsList1.Add(columns2);

            List<Header> header3 = new List<Header>();
            List<List<Column>> columnsList3 = new List<List<Column>>();

            header3.Add(new Header(6, false, false, 0, 3, "Header6", "Header36UIID"));
            header3.Add(new Header(7, false, false, 1, 3, "Header7", "Header37UIID"));

            List<Column> columns6 = new List<Column>();
            List<Column> columns7 = new List<Column>();
            columns6.Add(new Column(11, false, false, "Column11", 0, 3, "Column30UIID", 6));
            columns6.Add(new Column(12, false, false, "Column12", 1, 3, "Column31UIID", 6));
            columns7.Add(new Column(13, false, false, "Column13", 0, 3, "Column32UIID", 7));
            columns7.Add(new Column(14, false, false, "Column14", 1, 3, "Column33UIID", 7));
            columnsList2.Add(columns4);
            columnsList2.Add(columns5);
            columnsList3.Add(columns6);
            columnsList3.Add(columns7);

            List<Header> headers4 = new List<Header>();
            List<List<Column>> columnsList4 = new List<List<Column>>();

            headers4.Add(new Header(8, false, false, 0, 4, "Header8", "Header48UIID"));
            headers4.Add(new Header(9, false, false, 1, 4, "Header9", "Header49UIID"));

            List<Column> columns8 = new List<Column>();
            List<Column> columns9 = new List<Column>();
            columns8.Add(new Column(15, false, false, "Column15", 0, 4, "Column50UIID", 8));
            columns8.Add(new Column(16, false, false, "Column16", 1, 4, "Column51UIID", 8));
            columns9.Add(new Column(17, false, false, "Column17", 0, 4, "Column52UID", 9));
            columns9.Add(new Column(18, false, false, "Column18", 1, 4, "Column53UIID", 9));

            _table.Add(new Table(0, false, false, 0, headers0, columnsList0, "First", "TableTitle0", 4));
            _table.Add(new Table(1, false, true, 1, headers1, columnsList1, "Second", "TableTitle1", 5));
            _table.Add(new Table(2, true, false, 2, header2, columnsList2, "Non", "TableTitle2", 6));
            _table.Add(new Table(3, true, true, 3, header3, columnsList3, null, "TableTitle3", 7));
            _table.Add(new Table(4, false, false, 4, headers4, columnsList4, "Multiple", "TableTitle4", 8));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Table_Ctor(int Id)
        {
            //Arrange
            SetUp();
            var table = _table.Where(x => x.Id == Id).FirstOrDefault();

            //Act
            var tableConcrete = new UIFactory.Factory.Concrete.Table.Table(table,jsonLDService);

            //Assert
            Assert.Equal(table, tableConcrete.TableData);
            Assert.Equal(table.DisplayOrder, tableConcrete.DisplayOrder);
            Assert.Equal(table.UIConcreteType, tableConcrete.UIConcreteType);

            switch (Id)
            {
                case 0:
                    Assert.Equal("First", tableConcrete.JsonLDDatas[0].UIId);
                    break;
                case 1:
                    Assert.Equal("Second", tableConcrete.JsonLDDatas[0].UIId);
                    break;
                case 2:
                    Assert.Equal(0, tableConcrete.JsonLDDatas.Count());
                    break;
                case 3:
                    Assert.Equal(null, tableConcrete.JsonLDDatas[0].UIId);
                    break;
                case 4:
                    Assert.Equal("Multiple", tableConcrete.JsonLDDatas[0].UIId);
                    Assert.Equal("Multiple", tableConcrete.JsonLDDatas[1].UIId);
                    Assert.NotEqual(tableConcrete.JsonLDDatas[0], tableConcrete.JsonLDDatas[1]);

                    break;

            }
            TearDown();
        }

        //Table_Ctor_NullJsonLDService
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Table_Ctor_NullJsonLDService(int Id)
        {
            //Arrange
            SetUp();
            var table = _table.Where(x => x.Id == Id).FirstOrDefault();

            //Act
            var tableConcrete = new UIFactory.Factory.Concrete.Table.Table(table, null);

            //Assert
            Assert.Equal(table, tableConcrete.TableData);
            Assert.Equal(table.DisplayOrder, tableConcrete.DisplayOrder);
            Assert.Equal(table.UIConcreteType, tableConcrete.UIConcreteType);
            switch (Id)
            {
                case 0:
                    Assert.Null(tableConcrete.JsonLDDatas);
                    break;
                case 1:
                    Assert.Null(tableConcrete.JsonLDDatas);
                    break;
                case 2:
                    Assert.Null(tableConcrete.JsonLDDatas);
                    break;
                case 3:
                    Assert.Null(tableConcrete.JsonLDDatas);
                    break;
                case 4:
                    Assert.Null(tableConcrete.JsonLDDatas);
                    break;

            }
            TearDown();
        }


        public void TearDown()
        {
            _table = null;
        }


    }
}

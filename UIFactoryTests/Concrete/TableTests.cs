using Infrastructure.Models.Data.Table;

namespace UIFactoryTests.Concrete
{
    public class TableTests
    {
        private List<Table> _table;

        public void SetUp()
        {
            List<Header> headers0 = new List<Header>();
            List<List<Column>> columnsList0 = new List<List<Column>>();

            headers0.Add(new Header(0, false, false, 0, 0, "Header0", "Header00GUID"));
            headers0.Add(new Header(1, false, false, 1, 0, "Header1", "Header01GUID"));
            List<Column> columns0 = new List<Column>();
            List<Column> columns1 = new List<Column>();
            columns0.Add(new Column(0, false, false, "Column0", 0, 0, "Column00GUID", 0));
            columns0.Add(new Column(1, false, false, "Column1", 1, 0, "Column01GUID", 0));
            columns1.Add(new Column(2, false, false, "Column2", 0, 0, "Column02GUID", 1));
            columns1.Add(new Column(3, false, false, "Column3", 1, 0, "Column03GUID", 1));
            columnsList0.Add(columns0);
            columnsList0.Add(columns1);

            List<Header> headers1 = new List<Header>();
            List<List<Column>> columnsList1 = new List<List<Column>>();

            headers1.Add(new Header(2, false, false, 0, 1, "Header2", "Header12GUID"));
            headers1.Add(new Header(3, false, false, 1, 1, "Header3", "Header13GUID"));
            List<Column> columns2 = new List<Column>();
            List<Column> columns3 = new List<Column>();
            columns2.Add(new Column(4, false, false, "Column4", 0, 1, "Column10GUID", 2));
            columns2.Add(new Column(5, false, false, "Column5", 1, 1, "Column11GUID", 2));
            columns3.Add(new Column(6, false, false, "Column6", 0, 1, "Column12GUID", 3));

            List<Header> header2 = new List<Header>();
            List<List<Column>> columnsList2 = new List<List<Column>>();

            header2.Add(new Header(4, false, false, 0, 2, "Header4", "Header24GUID"));
            header2.Add(new Header(5, false, false, 1, 2, "Header5", "Header25GUID"));

            List<Column> columns4 = new List<Column>();
            List<Column> columns5 = new List<Column>();
            columns4.Add(new Column(7, false, false, "Column7", 0, 2, "Column20GUID", 4));
            columns4.Add(new Column(8, false, false, "Column8", 1, 2, "Column21GUID", 4));
            columns5.Add(new Column(9, false, false, "Column9", 0, 2, "Column22GUID", 5));
            columns5.Add(new Column(10, false, false, "Column10", 1, 2, "Column23GUID", 5));
            columnsList1.Add(columns2);

            List<Header> header3 = new List<Header>();
            List<List<Column>> columnsList3 = new List<List<Column>>();

            header3.Add(new Header(6, false, false, 0, 3, "Header6", "Header36GUID"));
            header3.Add(new Header(7, false, false, 1, 3, "Header7", "Header37GUID"));
            
            List<Column> columns6 = new List<Column>();
            List<Column> columns7 = new List<Column>();
            columns6.Add(new Column(11, false, false, "Column11", 0, 3, "Column30GUID", 6));
            columns6.Add(new Column(12, false, false, "Column12", 1, 3, "Column31GUID", 6));
            columns7.Add(new Column(13, false, false, "Column13", 0, 3, "Column32GUID", 7));
            columns7.Add(new Column(14, false, false, "Column14", 1, 3, "Column33GUID", 7));
            columnsList2.Add(columns4);
            columnsList2.Add(columns5);
            columnsList3.Add(columns6);
            columnsList3.Add(columns7);

            List<Header> headers4 = new List<Header>();
            List<List<Column>> columnsList4 = new List<List<Column>>();

            headers4.Add(new Header(8, false, false, 0, 4, "Header8", "Header48GUID"));
            headers4.Add(new Header(9, false, false, 1, 4, "Header9", "Header49GUID"));

            List<Column> columns8 = new List<Column>();
            List<Column> columns9 = new List<Column>();
            columns8.Add(new Column(15, false, false, "Column15", 0, 4, "Column50GUID", 8));
            columns8.Add(new Column(16, false, false, "Column16", 1, 4, "Column51GUID", 8));
            columns9.Add(new Column(17, false, false, "Column17", 0, 4, "Column52UID", 9));
            columns9.Add(new Column(18, false, false, "Column18", 1, 4, "Column53GUID", 9));

            _table.Add(new Table(0, false, false, 0, headers0, columnsList0, "First", "TableTitle0", 4));
            _table.Add(new Table(1, false, true, 1, headers1, columnsList1, "Second", "TableTitle1", 5));
            _table.Add(new Table(2, true, false, 2, header2, columnsList2, "Non", "TableTitle2", 6));
            _table.Add(new Table(3, true, true, 3, header3, columnsList3, null, "TableTitle3", 7));
            _table.Add(new Table(4, false, false, 4, headers4, columnsList4, "Multiple", "TableTitle4", 8));


        }

        public void TearDown()
        {

        }


    }
}

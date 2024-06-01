using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Table;
using System;

namespace InfrastructureTests.Ctor
{
    public class TableTests
    {
        private List<Header> headers = new List<Header>(); 
        private List<List<Column>> columnsList = new List<List<Column>>();

        private void SetUp()
        {
            headers.Add(new Header(0, false, false, 0, 0, "Header0", "Header0GUID"));
            headers.Add(new Header(1, false, false, 1, 0, "Header1", "Header1GUID"));
            List<Column> columns0 = new List<Column>();
            List<Column> columns1 = new List<Column>();
            columns0.Add(new Column(0,false,false,"Column0",0,0,"Column0GUID",0));
            columns0.Add(new Column(1, false, false, "Column1", 1, 0, "Column1GUID",0));
            columns1.Add(new Column(2, false, false, "Column2", 0, 0, "Column2GUID", 1));
            columns1.Add(new Column(3, false, false, "Column3", 1, 0, "Column3GUID",1));
            columnsList.Add(columns0);
            columnsList.Add(columns1);
        }

        [Fact]
        public void Table_DefaultConstructor_InitializesProperties()
        {
            // Arrange & Act
            var table = new Table();

            // Assert
            Assert.Equal(0, table.Id);
            Assert.Null(table.Title);
            Assert.False(table.Deleted);
            Assert.False(table.Inactive);
            Assert.Null(table.Headers);
            Assert.Null(table.Columns);
            Assert.Null(table.DisplayOrder);
            Assert.Null(table.GUID);
            Assert.Equal(UIConcrete.Table, table.UIConcreteType);
        }

 
        [Theory]
        [InlineData(0, true, false, 3, "TablePage0", "Table0GUID", "TableTitle0")]
        [InlineData(1, false, true, 2, "TablePage1", "Table1GUID", "TableTitle1")]
        [InlineData(2, true, true, 1, "TablePage2", "Table2GUID", "TableTitle2")]
        [InlineData(3, false, false, 0, "TablePage3", "Table3GUID", "TableTitle3")]
        public void Table_SetProperties_PropertiesAreSetCorrectly(int id, bool deleted, bool inactive, int displayOrder, string tablePage, string gUID, string title)
        {
            SetUp();
            var table = new Table(id, deleted, inactive, displayOrder, headers, columnsList, tablePage, gUID, title, 1);
            
            Assert.Equal(id, table.Id);
            Assert.Equal(title, table.Title);
            Assert.Equal(deleted, table.Deleted);
            Assert.Equal(inactive, table.Inactive);
            Assert.Equal(displayOrder, table.DisplayOrder);
            Assert.Equal(gUID, table.GUID);
            Assert.Equal(headers, table.Headers);
            Assert.Equal(columnsList, table.Columns);
            Assert.Equal(UIConcrete.Table, table.UIConcreteType);
            TearDown();
        }

        [Theory]
        [InlineData(0, true, false, 3, "TablePage0", "Table0GUID", "TableTitle0")]
        public void Table_SetProperties_NullColumns(int id, bool deleted, bool inactive, int displayOrder, string tablePage, string gUID, string title)
        {
            SetUp();
            var table = new Table(id, deleted, inactive, displayOrder, headers, null, tablePage, gUID, title, 1);

            Assert.Equal(id, table.Id);
            Assert.Equal(title, table.Title);
            Assert.Equal(deleted, table.Deleted);
            Assert.Equal(inactive, table.Inactive);
            Assert.Equal(displayOrder, table.DisplayOrder);
            Assert.Equal(gUID, table.GUID);
            Assert.Equal(headers, table.Headers);
            Assert.Equal(null, table.Columns);
            Assert.Equal(UIConcrete.Table, table.UIConcreteType);
            TearDown();
        }

        [Theory]
        [InlineData(0, true, false, 3, "TablePage0", "Table0GUID", "TableTitle0")]
        public void Table_SetProperties_HeadersNull(int id, bool deleted, bool inactive, int displayOrder, string tablePage, string gUID, string title)
        {
            SetUp();
            var table = new Table(id, deleted, inactive, displayOrder, null, columnsList, tablePage, gUID, title, 1);

            Assert.Equal(id, table.Id);
            Assert.Equal(title, table.Title);
            Assert.Equal(deleted, table.Deleted);
            Assert.Equal(inactive, table.Inactive);
            Assert.Equal(displayOrder, table.DisplayOrder);
            Assert.Equal(gUID, table.GUID);
            Assert.Null(table.Headers);
            Assert.Equal(columnsList, table.Columns);
            Assert.Equal(UIConcrete.Table, table.UIConcreteType);
            TearDown();
        }

        private void TearDown()
        {
            headers.Clear();
            columnsList.Clear();
        }
    }
}
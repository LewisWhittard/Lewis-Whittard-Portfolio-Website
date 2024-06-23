using Infrastructure.Models.Data.Table;

namespace UIFactoryTests.Concrete
{
    public class ColumnTests
    {
        private List<Column> _columns;

        //setup
        public void SetUp()
        {
            _columns = new List<Column>();
            _columns.Add(new Column(0,false,false,"ColumnValue",2,3,"ColumnGUID",0));
            _columns.Add(new Column(1, false, false, "ColumnValue", 3, 4, "ColumnGUID", 1));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Column_Ctor(int Id)
        {
            //Arrange
            SetUp();
            var column = _columns.Where(x => x.Id == Id).FirstOrDefault();

            //Act
            var columnConcrete = new UIFactory.Factory.Concrete.Table.Column(column);

            //Assert
            Assert.Equal(column, columnConcrete.ColumnData);
            Assert.Equal(column.DisplayOrder, columnConcrete.DisplayOrder);
            Assert.Equal(column.UIConcreteType, columnConcrete.UIConcreteType);

            TearDown();
        }

        public void TearDown()
        {
            _columns = null;
        }
    }
}

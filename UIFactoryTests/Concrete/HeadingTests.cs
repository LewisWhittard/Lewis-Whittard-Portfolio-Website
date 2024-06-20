using Infrastructure.Models.Data.InformationBlock;

namespace UIFactoryTests.Concrete
{
    public class HeadingTests
    {
        public class ParagraphTests
        {
            private List<Heading> _headings;

            //setup
            public void SetUp()
            {
                _headings = new List<Heading>();
                _headings.Add(new Heading(0,false,false,"Heading0Text",0,0,"Heading0GUID",0));
                _headings.Add(new Heading(1, false, false, "Heading1Text", 1, 1, "Heading1GUID", 1));
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            public void Heading_Ctor(int Id)
            {
                //Arrange
                SetUp();
                var heading = _headings.Where(x => x.Id == Id).FirstOrDefault();

                //Act
                var headingConcrete = new UIFactory.Factory.Concrete.InformationBlock.Heading(heading);

                //Assert
                Assert.NotNull(headingConcrete);
                Assert.Equal(heading, headingConcrete.HeadingData);
                Assert.Equal(heading.DisplayOrder, headingConcrete.DisplayOrder);
                Assert.Equal(heading.UIConcreteType, headingConcrete.UIConcreteType);

                TearDown();
            }

            public void TearDown()
            {
                _headings = null;
            }
        }
    }
}

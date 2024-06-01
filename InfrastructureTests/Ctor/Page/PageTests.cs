using Infrastructure.Models.Data.Interface;

namespace InfrastructureTests.Ctor
{
    public class PageTests
    {
        [Fact]
        public void Page_Constructor_NoParameters()
        {
            //arrange, act
            Infrastructure.Models.Data.Page.Page page = new Infrastructure.Models.Data.Page.Page();

            //assert
            Assert.Null(page.PageName);
            Assert.Null(page.Cards);
            Assert.Null(page.Carousels);
            Assert.Null(page.CarouselCards);
            Assert.Null(page.InformationBlocks);
            Assert.Null(page.Tables);
            Assert.Null(page.GUID);
            Assert.Equal(0,page.Id);
            Assert.False(page.Deleted);
            Assert.False(page.Inactive);
            Assert.Equal(UIConcrete.Page, page.UIConcreteType);
        }
    }
}

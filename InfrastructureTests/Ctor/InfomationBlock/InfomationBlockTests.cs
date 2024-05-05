using Infrastructure.Models.Data.Interface;

namespace InfrastructureTests.Ctor.InfomationBlock
{
    public class InfomationBlockTests
    {
        [Fact]
        public void InfomationBlock_Constructor_NoParameters()
        {
            //arrange, act
            Infrastructure.Models.Data.InfomationBlock.InfomatonBlock infomationBlock = new Infrastructure.Models.Data.InfomationBlock.InfomatonBlock();

            //assert
            Assert.Equal(0, infomationBlock.Id);
            Assert.False(infomationBlock.Deleted);
            Assert.False(infomationBlock.Inactive);
            Assert.Null(infomationBlock.Images);
            Assert.Null(infomationBlock.Paragraphs);
            Assert.Null(infomationBlock.Headings);
            Assert.Null(infomationBlock.DisplayOrder);
            Assert.Null(infomationBlock.GUID);
            Assert.Equal(UIConcrete.InfomationBlock, infomationBlock.UIConcreteType);
        }
    }
}
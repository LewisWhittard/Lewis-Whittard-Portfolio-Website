using Infrastructure.Models.Data.Interface;

namespace InfrastructureTests.Ctor
{
    public class InformationBlockTests
    {
        [Fact]
        public void InformationBlock_Constructor_NoParameters()
        {
            //arrange, act
            Infrastructure.Models.Data.InformationBlock.InfomatonBlock informationBlock = new Infrastructure.Models.Data.InformationBlock.InfomatonBlock();

            //assert
            Assert.Equal(0, informationBlock.Id);
            Assert.False(informationBlock.Deleted);
            Assert.False(informationBlock.Inactive);
            Assert.Null(informationBlock.Images);
            Assert.Null(informationBlock.Paragraphs);
            Assert.Null(informationBlock.Headings);
            Assert.Null(informationBlock.DisplayOrder);
            Assert.Null(informationBlock.GUID);
            Assert.Equal(UIConcrete.InformationBlock, informationBlock.UIConcreteType);
        }
    }
}
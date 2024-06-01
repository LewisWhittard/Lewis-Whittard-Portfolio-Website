using Infrastructure.Models.Data.InformationBlock;
using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Image;

namespace InfrastructureTests.Ctor
{
    public class InformationBlockTests
    {
        private List<Heading> _headings { get; set; }
         private List<Paragraph> _paragraphs { get; set; }
        private List<Image> _images { get; set; }

        //SetUp
        public InformationBlockTests()
        {
            _headings = new List<Heading>();
            _paragraphs = new List<Paragraph>();
            _images = new List<Image>();

            Heading heading1 = new Heading(0, false, false, "Heading0Test", 0, 0, "Heading0GUID", 0);
            Heading heading2 = new Heading(1, false, false, "Heading1Test", 0, 0, "Heading1GUID", 0);
            Paragraph paragraph1 = new Paragraph("Paragrapth1Text", 0, 0, false, false, 0, "Paragrath1GUID");
            Paragraph Paragraph2 = new Paragraph("Paragrapth2Text", 0, 0, false, false, 0, "Paragrath2GUID");
            Image Image1 = new Image("Image1Source", 0, 0, false, false, "Image1GUID");
            Image Image2 = new Image("Image2Source", 0, 0, false, false, "Image2gUID");
        }


        [Fact]
        public void InformationBlock_Constructor_NoParameters()
        {
            //arrange, act
            InfomatonBlock informationBlock = new InfomatonBlock();

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

        [Theory]
        [InlineData(0, false, false, 0, "GUID", "PageName")]
        [InlineData(1, true, true, 1, "GUID1", "PageName1")]
        [InlineData(2, false, true, 2, "GUID2", "PageName2")]
        [InlineData(3, true, false, 3, "GUID3", "PageName3")]
        public void InformationBlock_SetProperties_PropertiesAreSetCorrectly(int id, bool deleted, bool inactive, int displayOrder, string gUID, string pageName)
        {
            //arrange, act
            InfomatonBlock informationBlock = new InfomatonBlock(id, deleted, inactive, _images, _paragraphs, _headings, displayOrder, gUID, pageName);

            //assert
            Assert.Equal(id, informationBlock.Id);
            Assert.Equal(deleted, informationBlock.Deleted);
            Assert.Equal(inactive, informationBlock.Inactive);
            Assert.Equal(_images, informationBlock.Images);
            Assert.Equal(_paragraphs, informationBlock.Paragraphs);
            Assert.Equal(_headings, informationBlock.Headings);
            Assert.Equal(displayOrder, informationBlock.DisplayOrder);
            Assert.Equal(gUID, informationBlock.GUID);
            Assert.Equal(pageName, informationBlock.PageName);
            Assert.Equal(UIConcrete.InformationBlock, informationBlock.UIConcreteType);

            TearDown();
        }

        //InformationBlock_SetProperties_PropertiesAreSetCorrectlyAllowNullImages
        [Fact]
        public void InformationBlock_SetProperties_PropertiesAreSetCorrectlyAllowNullImages()
        {
            //arrange, act
            InfomatonBlock informationBlock = new InfomatonBlock(0, false, false, null, _paragraphs, _headings, 0, "GUID", "PageName");

            //assert
            Assert.Equal(0, informationBlock.Id);
            Assert.False(informationBlock.Deleted);
            Assert.False(informationBlock.Inactive);
            Assert.Null(informationBlock.Images);
            Assert.Equal(_paragraphs, informationBlock.Paragraphs);
            Assert.Equal(_headings, informationBlock.Headings);
            Assert.Equal(0, informationBlock.DisplayOrder);
            Assert.Equal("GUID", informationBlock.GUID);
            Assert.Equal("PageName", informationBlock.PageName);
            Assert.Equal(UIConcrete.InformationBlock, informationBlock.UIConcreteType);

            TearDown();
        }

        //InformationBlock_SetProperties_PropertiesAreSetCorrectlyAllowNullParagraphs
        [Fact]
        public void InformationBlock_SetProperties_PropertiesAreSetCorrectlyAllowNullParagraphs()
        {
            //arrange, act
            InfomatonBlock informationBlock = new InfomatonBlock(0, false, false, _images, null, _headings, 0, "GUID", "PageName");

            //assert
            Assert.Equal(0, informationBlock.Id);
            Assert.False(informationBlock.Deleted);
            Assert.False(informationBlock.Inactive);
            Assert.Equal(_images, informationBlock.Images);
            Assert.Null(informationBlock.Paragraphs);
            Assert.Equal(_headings, informationBlock.Headings);
            Assert.Equal(0, informationBlock.DisplayOrder);
            Assert.Equal("GUID", informationBlock.GUID);
            Assert.Equal("PageName", informationBlock.PageName);
            Assert.Equal(UIConcrete.InformationBlock, informationBlock.UIConcreteType);
        }

        //InformationBlock_SetProperties_PropertiesAreSetCorrectlyAllowNullHeadings
        [Fact]
        public void InformationBlock_SetProperties_PropertiesAreSetCorrectlyAllowNullHeadings()
        {
            //arrange, act
            InfomatonBlock informationBlock = new InfomatonBlock(0, false, false, _images, _paragraphs, null, 0, "GUID", "PageName");

            //assert
            Assert.Equal(0, informationBlock.Id);
            Assert.False(informationBlock.Deleted);
            Assert.False(informationBlock.Inactive);
            Assert.Equal(_images, informationBlock.Images);
            Assert.Equal(_paragraphs, informationBlock.Paragraphs);
            Assert.Null(informationBlock.Headings);
            Assert.Equal(0, informationBlock.DisplayOrder);
            Assert.Equal("GUID", informationBlock.GUID);
            Assert.Equal("PageName", informationBlock.PageName);
            Assert.Equal(UIConcrete.InformationBlock, informationBlock.UIConcreteType);

            TearDown();
        }

        public void TearDown()
        {
            _headings = null;
            _paragraphs = null;
            _images = null;
        }
    }
}
using Infrastructure.Models.Data.InformationBlock;
using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Image;

namespace InfrastructureTests.Model
{
    public class InformationBlockTests
    {
        private List<Heading> _headings { get; set; }
         private List<Paragraph> _paragraphs { get; set; }
        private List<Image> _images { get; set; }

        //SetUp
        public void SetUp()
        {
            _headings = new List<Heading>
            {
                new Heading(0, false, false, "Heading0Test", 0, 0, "Heading0UIID", 0),
                new Heading(1, false, false, "Heading1Test", 0, 0, "Heading1UIID", 0)
            };

            _paragraphs = new List<Paragraph>
            {
                new Paragraph("Paragrapth1Text", 0, 0, false, false, 0, "Paragrath1UIID"),
                new Paragraph("Paragrapth2Text", 0, 0, false, false, 0, "Paragrath2UIID")
            };

            _images = new List<Image>
            {
                new Image("Image1Source", 0, 0, false, false, "Image1UIID", null, null, null),
                new Image("Image2Source", 0, 0, false, false, "Image2uIId", null, null, null)
            };
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
            Assert.Null(informationBlock.UIID);
            Assert.Equal(UIConcrete.InformationBlock, informationBlock.UIConcreteType);
            Assert.Equal(informationBlock.PageId,0);
        }

        [Theory]
        [InlineData(0, false, false, 3, "UIID",6)]
        [InlineData(1, true, true, 2, "UIID1",7)]
        [InlineData(2, false, true, 4, "UIID2",8)]
        [InlineData(3, true, false, 4, "UIID3",9)]
        [InlineData(3, true, false, 3, "UIID3",10)]
        public void InformationBlock_SetProperties_PropertiesAreSetCorrectly(int id, bool deleted, bool inactive, int displayOrder, string uIId,int pageId)
        {
            //arrange, act
            SetUp();
            InfomatonBlock informationBlock = new InfomatonBlock(id, deleted, inactive, _images, _paragraphs, _headings, displayOrder, uIId, pageId);

            //assert
            Assert.Equal(id, informationBlock.Id);
            Assert.Equal(deleted, informationBlock.Deleted);
            Assert.Equal(inactive, informationBlock.Inactive);
            Assert.Equal(_images, informationBlock.Images);
            Assert.Equal(_paragraphs, informationBlock.Paragraphs);
            Assert.Equal(_headings, informationBlock.Headings);
            Assert.Equal(displayOrder, informationBlock.DisplayOrder);
            Assert.Equal(uIId, informationBlock.UIID);
            Assert.Equal(UIConcrete.InformationBlock, informationBlock.UIConcreteType);
            Assert.Equal(pageId, informationBlock.PageId);

            TearDown();
        }

        //InformationBlock_SetProperties_PropertiesAreSetCorrectlyAllowNullImages
        [Fact]
        public void InformationBlock_SetProperties_PropertiesAreSetCorrectlyAllowNullImages()
        {
            //arrange, act
            SetUp();
            InfomatonBlock informationBlock = new InfomatonBlock(0, false, false, null, _paragraphs, _headings, 0, "UIID",1);

            //assert
            Assert.Equal(0, informationBlock.Id);
            Assert.False(informationBlock.Deleted);
            Assert.False(informationBlock.Inactive);
            Assert.Null(informationBlock.Images);
            Assert.Equal(_paragraphs, informationBlock.Paragraphs);
            Assert.Equal(_headings, informationBlock.Headings);
            Assert.Equal(0, informationBlock.DisplayOrder);
            Assert.Equal("UIID", informationBlock.UIID);
            Assert.Equal(UIConcrete.InformationBlock, informationBlock.UIConcreteType);
            Assert.Equal(1, informationBlock.PageId);

            TearDown();
        }

        //InformationBlock_SetProperties_PropertiesAreSetCorrectlyAllowNullParagraphs
        [Fact]
        public void InformationBlock_SetProperties_PropertiesAreSetCorrectlyAllowNullParagraphs()
        {
            //arrange, act
            SetUp();
            InfomatonBlock informationBlock = new InfomatonBlock(0, false, false, _images, null, _headings, 0, "UIID",1);

            //assert
            Assert.Equal(0, informationBlock.Id);
            Assert.False(informationBlock.Deleted);
            Assert.False(informationBlock.Inactive);
            Assert.Equal(_images, informationBlock.Images);
            Assert.Null(informationBlock.Paragraphs);
            Assert.Equal(_headings, informationBlock.Headings);
            Assert.Equal(0, informationBlock.DisplayOrder);
            Assert.Equal("UIID", informationBlock.UIID);
            Assert.Equal(UIConcrete.InformationBlock, informationBlock.UIConcreteType);
            Assert.Equal(1, informationBlock.PageId);

            TearDown();
        }

        //InformationBlock_SetProperties_PropertiesAreSetCorrectlyAllowNullHeadings
        [Fact]
        public void InformationBlock_SetProperties_PropertiesAreSetCorrectlyAllowNullHeadings()
        {
            //arrange, act
            SetUp();
            InfomatonBlock informationBlock = new InfomatonBlock(0, false, false, _images, _paragraphs, null, 0, "UIID",1);

            //assert
            Assert.Equal(0, informationBlock.Id);
            Assert.False(informationBlock.Deleted);
            Assert.False(informationBlock.Inactive);
            Assert.Equal(_images, informationBlock.Images);
            Assert.Equal(_paragraphs, informationBlock.Paragraphs);
            Assert.Null(informationBlock.Headings);
            Assert.Equal(0, informationBlock.DisplayOrder);
            Assert.Equal("UIID", informationBlock.UIID);
            Assert.Equal(UIConcrete.InformationBlock, informationBlock.UIConcreteType);
            Assert.Equal(1, informationBlock.PageId);

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
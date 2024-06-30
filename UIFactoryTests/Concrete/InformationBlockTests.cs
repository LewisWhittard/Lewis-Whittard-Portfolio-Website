using Infrastructure.Models.Data.InformationBlock;
using SEO.Repository.AltRepository;
using SEO.Repository.JsonLDRepositoryRepository;
using SEO.Service.AltService;
using SEO.Service.JsonLDService;

namespace UIFactoryTests.Concrete
{

    public class InformationBlockTests
    {
        private List<InfomatonBlock> _informationBlocks;
        private JsonLDService _jsonLDService;
        private AltService _AltService;

        public void SetUp()
        {
            _informationBlocks = new List<InfomatonBlock>();
            _jsonLDService = new JsonLDService(new MockJsonLDRepository());
            _AltService = new AltService(new MockAltRepository());

            var paragraphs0 = new List<Paragraph>();
            paragraphs0.Add(new Paragraph("Paragraph00", 0, 0, false, false, 0, "ParagraphUIID00"));
            paragraphs0.Add(new Paragraph("Paragraph01", 1, 0, false, false, 0, "ParagraphUIID01"));

            var paragraphs1 = new List<Paragraph>();
            paragraphs1.Add(new Paragraph("Paragraph10", 0, 1, false, false, 1, "ParagraphUIID10"));
            paragraphs1.Add(new Paragraph("Paragraph11", 1, 1, false, false, 1, "ParagraphUIID11"));

            var paragraphs2 = new List<Paragraph>();
            paragraphs2.Add(new Paragraph("Paragraph20", 0, 2, false, false, 2, "ParagraphUIID20"));
            paragraphs2.Add(new Paragraph("Paragraph21", 1, 2, false, false, 2, "ParagraphUIID21"));

            var paragraphs3 = new List<Paragraph>();
            paragraphs3.Add(new Paragraph("Paragraph30", 0, 3, false, false, 3, "ParagraphUIID30"));
            paragraphs3.Add(new Paragraph("Paragraph31", 1, 3, false, false, 3, "ParagraphUIID31"));

            var paragraphs4 = new List<Paragraph>();
            paragraphs4.Add(new Paragraph("Paragraph40", 0, 4, false, false, 4, "ParagraphUIID40"));
            paragraphs4.Add(new Paragraph("Paragraph41", 1, 4, false, false, 4, "ParagraphUIID41"));

            var headings0 = new List<Heading>();
            headings0.Add(new Heading(0, false, false, "Heading00Text", 0, 0, "Heading00UIID", 0));
            headings0.Add(new Heading(1, false, false, "Heading01Text", 1, 0, "Heading01UIID", 1));

            var headings1 = new List<Heading>();
            headings1.Add(new Heading(0, false, false, "Heading10Text", 0, 1, "Heading10UIID", 0));
            headings1.Add(new Heading(1, false, false, "Heading11Text", 1, 1, "Heading11UIID", 1));

            var headings2 = new List<Heading>();
            headings2.Add(new Heading(0, false, false, "Heading20Text", 0, 2, "Heading20UIID", 0));
            headings2.Add(new Heading(1, false, false, "Heading21Text", 1, 2, "Heading21UIID", 1));

            var headings3 = new List<Heading>();
            headings3.Add(new Heading(0, false, false, "Heading30Text", 0, 3, "Heading30UIID", 0));
            headings3.Add(new Heading(1, false, false, "Heading31Text", 1, 3, "Heading31UIID", 1));

            var headings4 = new List<Heading>();
            headings4.Add(new Heading(0, false, false, "Heading40Text", 0, 4, "Heading40UIID", 0));
            headings4.Add(new Heading(1, false, false, "Heading41Text", 1, 4, "Heading41UIID", 1));

            var imageDatas0 = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas0.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 0, false, false, "First", null, 0, null));
            imageDatas0.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 1, 1, false, false, "Second", null, 0, null));

            var imageDatas1 = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas1.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 2, false, false, "Image10UIID", null, 1, null));
            imageDatas1.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 1, 3, false, false, "Image11UIID", null, 1, null));

            var imageDatas2 = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas2.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 4, false, false, "Image20UIID", null, 2, null));
            imageDatas2.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 1, 5, false, false, "Image21UIID", null, 2, null));

            var imageDatas3 = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas3.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 6, false, false, "Image30UIID", null, 3, null));
            imageDatas3.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 1, 7, false, false, "Image31UIID", null, 3, null));

            var imageDatas4 = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas4.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 8, false, false, "Image40UIID", null, 4, null));
            imageDatas4.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 1, 9, false, false, "Image41UIID", null, 4, null));

            _informationBlocks.Add((new InfomatonBlock(0, false, false, imageDatas0, paragraphs0, headings0, 4, "First", 0)));
            _informationBlocks.Add((new InfomatonBlock(1, false, false, imageDatas1, paragraphs1, headings1, 3, "Second", 1)));
            _informationBlocks.Add((new InfomatonBlock(2, false, false, imageDatas2, paragraphs2, headings2, 2, "Non", 2)));
            _informationBlocks.Add((new InfomatonBlock(3, false, false, imageDatas3, paragraphs3, headings3, 1, null, 3)));
            _informationBlocks.Add((new InfomatonBlock(4, false, false, imageDatas4, paragraphs4, headings4, 0, "Multiple", 4)));

        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void InformationBlock_Ctor(int Id)
        {
            //Arrange
            SetUp();
            var informationBlock = _informationBlocks.Where(x => x.Id == Id).FirstOrDefault();

            //Act
            var informationBlockConcrete = new UIFactory.Factory.Concrete.InformationBlock.InformationBlock(informationBlock, _jsonLDService,_AltService);

            //Assert
            Assert.Equal(informationBlock, informationBlockConcrete.InformationBlockData);
            Assert.Equal(informationBlock.DisplayOrder, informationBlockConcrete.DisplayOrder);
            Assert.Equal(informationBlock.UIConcreteType, informationBlockConcrete.UIConcreteType);
            if (Id == 0)
            {
                Assert.Equal("First", informationBlockConcrete.Images.First().AltData.SuperClassUIID);
                Assert.Equal("Second", informationBlockConcrete.Images.Last().AltData.SuperClassUIID);
                Assert.Equal("First", informationBlockConcrete.Images.First().JsonLDDatas[0].SuperClassUIID);
                Assert.Equal("Second", informationBlockConcrete.Images.Last().JsonLDDatas[0].SuperClassUIID);
            }

            switch (Id)
            {
                case 0:
                    Assert.Equal("First", informationBlockConcrete.JsonLDDatas[0].SuperClassUIID);
                    break;
                case 1:
                    Assert.Equal("Second", informationBlockConcrete.JsonLDDatas[0].SuperClassUIID);
                    break;
                case 2:
                    Assert.Equal(0, informationBlockConcrete.JsonLDDatas.Count());
                    break;
                case 3:
                    Assert.Equal(null, informationBlockConcrete.JsonLDDatas[0].SuperClassUIID);
                    break;
                case 4:
                    Assert.Equal("Multiple", informationBlockConcrete.JsonLDDatas[0].SuperClassUIID);
                    Assert.Equal("Multiple", informationBlockConcrete.JsonLDDatas[1].SuperClassUIID);
                    Assert.NotEqual(informationBlockConcrete.JsonLDDatas[0], informationBlockConcrete.JsonLDDatas[1]);
                    break;

            }
            TearDown();
        }

        [Theory]
        [InlineData(0)]
        public void InformationBlock_Ctor_NullAltService(int Id)
        {
            //Arrange
            SetUp();
            var informationBlock = _informationBlocks.Where(x => x.Id == Id).FirstOrDefault();

            //Act
            var informationBlockConcrete = new UIFactory.Factory.Concrete.InformationBlock.InformationBlock(informationBlock, _jsonLDService, null);

            //Assert
            Assert.Equal(informationBlock, informationBlockConcrete.InformationBlockData);
            Assert.Equal(informationBlock.DisplayOrder, informationBlockConcrete.DisplayOrder);
            Assert.Equal(informationBlock.UIConcreteType, informationBlockConcrete.UIConcreteType);
            if (Id == 0)
            {
                Assert.Null(informationBlockConcrete.Images.First().AltData);
                Assert.Null(informationBlockConcrete.Images.Last().AltData);
                Assert.Equal("First", informationBlockConcrete.Images.First().JsonLDDatas[0].SuperClassUIID);
                Assert.Equal("Second", informationBlockConcrete.Images.Last().JsonLDDatas[0].SuperClassUIID);
            }

            switch (Id)
            {
                case 0:
                    Assert.Equal("First", informationBlockConcrete.JsonLDDatas[0].SuperClassUIID);
                    break;
            }
            TearDown();
        }


        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void InformationBlock_Ctor_NullJsonLDService(int Id)
        {
            //Arrange
            SetUp();
            var informationBlock = _informationBlocks.Where(x => x.Id == Id).FirstOrDefault();

            //Act
            var informationBlockConcrete = new UIFactory.Factory.Concrete.InformationBlock.InformationBlock(informationBlock, null, _AltService);

            //Assert
            Assert.Equal(informationBlock, informationBlockConcrete.InformationBlockData);
            Assert.Equal(informationBlock.DisplayOrder, informationBlockConcrete.DisplayOrder);
            Assert.Equal(informationBlock.UIConcreteType, informationBlockConcrete.UIConcreteType);
            if (Id == 0)
            {
                Assert.Equal("First", informationBlockConcrete.Images.First().AltData.SuperClassUIID);
                Assert.Equal("Second", informationBlockConcrete.Images.Last().AltData.SuperClassUIID);
                Assert.Null(informationBlockConcrete.Images.First().JsonLDDatas);
                Assert.Null(informationBlockConcrete.Images.Last().JsonLDDatas);
            }

            switch (Id)
            {
                case 0:
                    Assert.Null(informationBlockConcrete.JsonLDDatas);
                    break;
                case 1:
                    Assert.Null(informationBlockConcrete.JsonLDDatas);
                    break;
                case 2:
                    Assert.Null(informationBlockConcrete.JsonLDDatas);
                    break;
                case 3:
                    Assert.Null(informationBlockConcrete.JsonLDDatas);
                    break;
                case 4:
                    Assert.Null(informationBlockConcrete.JsonLDDatas);
                    break;

            }
            TearDown();
        }



        //teardown
        public void TearDown()
        {
            _informationBlocks = null;
        }

    }
}

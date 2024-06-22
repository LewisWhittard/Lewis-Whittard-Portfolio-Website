using SEO.Repository.AltRepository;
using SEO.Repository.JsonLDRepositoryRepository;
using SEO.Service.AltService;
using SEO.Service.JsonLDService;

namespace UIFactoryTests.Concrete
{
    public class ImageTests
    {
        private AltService _altService;
        private JsonLDService _jsonLDService;
        private List<Infrastructure.Models.Data.Shared.Image.Image> _imageDatas;

        public void Setup()
        {
            _imageDatas = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            MockAltRepository mockAltRepository = new MockAltRepository();
            _altService = new AltService(mockAltRepository);
            MockJsonLDRepository mockJsonLDRepository = new MockJsonLDRepository();
            _jsonLDService = new JsonLDService(mockJsonLDRepository);
            _imageDatas.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 1, 0, false, false, "First", null, null, null));
            _imageDatas.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 2, 1, false, false, "Second", null, null, null));
            _imageDatas.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 2, false, false, "Non", null, null, null));
            _imageDatas.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 3, false, false, null, null, null, null));
            _imageDatas.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 4, false, false, "Multiple", null, null, null));
            _imageDatas.Add(new Infrastructure.Models.Data.Shared.Image.Image("", null, 5, false, false, null, null, null, null));
        }


        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Image_Ctor_AltData(int imageId)
        {
            Setup();

            //Arrange
            var Image = _imageDatas.Where(x => x.Id == imageId).FirstOrDefault();
            //act
            var ImageConcrete = new UIFactory.Factory.Concrete.Shared.Image.Image(Image, _altService,null);

            //Assert
            switch (imageId)
            {
                case 0:
                    Assert.Equal(0, ImageConcrete.AltData.Id);
                    break;
                case 1:
                    Assert.Equal(1, ImageConcrete.AltData.Id);
                    break;
                case 2:
                    Assert.Null(ImageConcrete.AltData);
                    break;
                case 3:
                    Assert.Null(ImageConcrete.AltData);
                    break;
            }

            TearDown();
        }


        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Image_CtorNoService_AltData(int imageId)
        {
            Setup();

            //Arrange
            var Image = _imageDatas.Where(x => x.Id == imageId).FirstOrDefault();
            //act
            var ImageConcrete = new UIFactory.Factory.Concrete.Shared.Image.Image(Image, null, null);

            //Assert
            switch (imageId)
            {
                case 0:
                    Assert.Null(ImageConcrete.AltData);
                    break;
                case 1:
                    Assert.Null(ImageConcrete.AltData);
                    break;
                case 2:
                    Assert.Null(ImageConcrete.AltData);
                    break;
                case 3:
                    Assert.Null(ImageConcrete.AltData);
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
        public void Image_Ctor_JsonLDData(int imageId)
        {
            Setup();

            //Arrange
            var Image = _imageDatas.Where(x => x.Id == imageId).FirstOrDefault();
            //act
            var ImageConcrete = new UIFactory.Factory.Concrete.Shared.Image.Image(Image, null, _jsonLDService);

            //Assert
            switch (imageId)
            {
                case 0:
                    Assert.Equal(0, ImageConcrete.JsonLDs[0].Id);
                    break;
                case 1:
                    Assert.Equal(1, ImageConcrete.JsonLDs[0].Id);
                    break;
                case 2:
                    Assert.Equal(0, ImageConcrete.JsonLDs.Count());
                    break;
                case 3:
                    Assert.Equal(0, ImageConcrete.JsonLDs.Count());
                    break;
                case 4:
                    Assert.Equal(2, ImageConcrete.JsonLDs[0].Id);
                    Assert.Equal(3, ImageConcrete.JsonLDs[1].Id);
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
        public void Image_CtorNoService_JsonLDData(int imageId)
        {
            Setup();

            //Arrange
            var Image = _imageDatas.Where(x => x.Id == imageId).FirstOrDefault();
            //act
            var ImageConcrete = new UIFactory.Factory.Concrete.Shared.Image.Image(Image, null, null);

            //Assert
            switch (imageId)
            {
                case 0:
                    Assert.Null(ImageConcrete.JsonLDs);
                    break;
                case 1:
                    Assert.Null(ImageConcrete.JsonLDs);
                    break;
                case 2:
                    Assert.Null(ImageConcrete.JsonLDs);
                    break;
                case 3:
                    Assert.Null(ImageConcrete.JsonLDs);
                    break;
                case 4:
                    Assert.Null(ImageConcrete.JsonLDs);
                    break;
            }

            TearDown();
        }


        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public void Image_Ctor(int imageId)
        {
            Setup();

            //Arrange
            var Image = _imageDatas.Where(x => x.Id == imageId).FirstOrDefault();
            //act
            var ImageConcrete = new UIFactory.Factory.Concrete.Shared.Image.Image(Image, _altService, _jsonLDService);

            //Assert
            Assert.Equal(Image, ImageConcrete.ImageData);
            Assert.Equal(Image.DisplayOrder, ImageConcrete.DisplayOrder);
            Assert.Equal(Image.UIConcreteType, ImageConcrete.UIConcreteType);

            switch (imageId)
            {
                case 0:
                    Assert.Equal(0, ImageConcrete.JsonLDs[0].Id);
                    break;
                case 1:
                    Assert.Equal(1, ImageConcrete.JsonLDs[0].Id);
                    break;
            }

            switch (imageId)
            {
                case 0:
                    Assert.Equal(0, ImageConcrete.AltData.Id);
                    break;
                case 1:
                    Assert.Equal(1, ImageConcrete.AltData.Id);
                    break;
            }

            TearDown();
        }

        //teardown
        public void TearDown()
        {
            _altService = null;
            _jsonLDService = null;
            _imageDatas = null;
        }
    }
}

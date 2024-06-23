using SEO.Repository.AltRepository;
using SEO.Repository.JsonLDRepositoryRepository;
using SEO.Service.AltService;
using SEO.Service.JsonLDService;

namespace UIFactoryTests.Concrete
{
    public class CarouselTests
    {
        private List<Infrastructure.Models.Data.Carousel.Carousel> Carousels;
        private JsonLDService _jsonLDService;
        private AltService _altService;

        public void SetUp()
        {
            Carousels = new List<Infrastructure.Models.Data.Carousel.Carousel>();

            _jsonLDService = new JsonLDService(new  MockJsonLDRepository());
            _altService = new AltService(new MockAltRepository());

            var imageDatas0 = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas0.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 0, false, false, "First", null, 0, null));
            imageDatas0.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 1, 1, false, false, "Second", null, 0, null));

            var imageDatas1 = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas1.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 2, false, false, "Image10GUID", null, 1, null));
            imageDatas1.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 1, 3, false, false, "Image11GUID", null, 1, null));

            var imageDatas2 = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas2.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 4, false, false, "Image20GUID", null, 2, null));
            imageDatas2.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 1, 5, false, false, "Image21GUID", null, 2, null));

            var imageDatas3 = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas3.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 6, false, false, "Image30GUID", null, 3, null));
            imageDatas3.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 1, 7, false, false, "Image31GUID", null, 3, null));

            var imageDatas4 = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas4.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 8, false, false, "Image40GUID", null, 4, null));
            imageDatas4.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 1, 9, false, false, "Image41GUID", null, 4, null));

            Carousels.Add(new Infrastructure.Models.Data.Carousel.Carousel(0, false, false, imageDatas0, 0, "First", 0));
            Carousels.Add(new Infrastructure.Models.Data.Carousel.Carousel(1, false, false, imageDatas1, 1, "Second", 1));
            Carousels.Add(new Infrastructure.Models.Data.Carousel.Carousel(2, false, false, imageDatas2, 2, "Non", 2));
            Carousels.Add(new Infrastructure.Models.Data.Carousel.Carousel(3, false, false, imageDatas3, 3, null, 3));
            Carousels.Add(new Infrastructure.Models.Data.Carousel.Carousel(4, false, false, imageDatas4, 4, "Multiple", 4));

        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Carousel_Ctor(int Id)
        {
            //Arrange
            SetUp();
            var carousel = Carousels.Where(x => x.Id == Id).FirstOrDefault();

            //Act
            var carouselConcrete = new UIFactory.Factory.Concrete.Carousel.Carousel(carousel,_jsonLDService, _altService);

            //Assert
            Assert.Equal(carousel, carouselConcrete.CarouselData);
            Assert.Equal(carousel.DisplayOrder, carouselConcrete.DisplayOrder);
            Assert.Equal(carousel.UIConcreteType, carouselConcrete.UIConcreteType);
            if (Id == 0)
            {
                Assert.Equal("First", carouselConcrete.Images.First().AltData.SuperClassGUID);
                Assert.Equal("Second", carouselConcrete.Images.Last().AltData.SuperClassGUID);
            }

            switch (Id)
            {
                case 0:
                    Assert.Equal("First", carouselConcrete.JsonLDDatas[0].SuperClassGUID);
                    break;
                case 1:
                    Assert.Equal("Second", carouselConcrete.JsonLDDatas[0].SuperClassGUID);
                    break;
                case 2:
                    Assert.Equal(0, carouselConcrete.JsonLDDatas.Count());
                    break;
                case 3:
                    Assert.Equal(0, carouselConcrete.JsonLDDatas.Count());
                    break;
                case 4:
                    Assert.Equal("Multiple", carouselConcrete.JsonLDDatas[0].SuperClassGUID);
                    Assert.Equal("Multiple", carouselConcrete.JsonLDDatas[1].SuperClassGUID);
                    break;

            }
            TearDown();
        }

        [Theory]
        [InlineData(0)]
        public void Carousel_Ctor_NullAltService(int Id)
        {
            //Arrange
            SetUp();
            var carousel = Carousels.Where(x => x.Id == Id).FirstOrDefault();

            //Act
            var carouselConcrete = new UIFactory.Factory.Concrete.Carousel.Carousel(carousel, _jsonLDService,null);

            //Assert
            Assert.Equal(carousel, carouselConcrete.CarouselData);
            Assert.Equal(carousel.DisplayOrder, carouselConcrete.DisplayOrder);
            Assert.Equal(carousel.UIConcreteType, carouselConcrete.UIConcreteType);
            if (Id == 0)
            {
                Assert.Null(carouselConcrete.Images.First().AltData);
                Assert.Null(carouselConcrete.Images.Last().AltData);
            }

            switch (Id)
            {
                case 0:
                    Assert.Equal("First", carouselConcrete.JsonLDDatas[0].SuperClassGUID);
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
        public void Carousel_Ctor_NullJsonLDService(int Id)
        {
            //Arrange
            SetUp();
            var carousel = Carousels.Where(x => x.Id == Id).FirstOrDefault();

            //Act
            var carouselConcrete = new UIFactory.Factory.Concrete.Carousel.Carousel(carousel,null,_altService);

            //Assert
            Assert.Equal(carousel, carouselConcrete.CarouselData);
            Assert.Equal(carousel.DisplayOrder, carouselConcrete.DisplayOrder);
            Assert.Equal(carousel.UIConcreteType, carouselConcrete.UIConcreteType);
            if (Id == 0)
            {
                Assert.Equal("First", carouselConcrete.Images.First().AltData.SuperClassGUID);
                Assert.Equal("Second", carouselConcrete.Images.Last().AltData.SuperClassGUID);
            }

            switch (Id)
            {
                case 0:
                    Assert.Null(carouselConcrete.JsonLDDatas);
                    break;
                case 1:
                    Assert.Null(carouselConcrete.JsonLDDatas);
                    break;
                case 2:
                    Assert.Null(carouselConcrete.JsonLDDatas);
                    break;
                case 3:
                    Assert.Null(carouselConcrete.JsonLDDatas);
                    break;
                case 4:
                    Assert.Null(carouselConcrete.JsonLDDatas);
                    break;

            }
            TearDown();
        }

        public void TearDown()
        {
            Carousels = null;
        }
    }

}

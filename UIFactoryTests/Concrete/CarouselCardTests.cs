using Infrastructure.Models.Data.CarouselCard;
using Infrastructure.Models.Data.Shared.Card;
using SEO.Repository.AltRepository;
using SEO.Repository.JsonLDRepositoryRepository;
using SEO.Service.AltService;
using SEO.Service.JsonLDService;

namespace UIFactoryTests.Concrete
{
    public class CarouselCardTests
    {
        List<CarouselCard> _carouselCards;
        private AltService _AltService;
        private JsonLDService _JsonLDService;

        public void SetUp()
        {
            _carouselCards = new List<CarouselCard>();
            _AltService = new AltService(new MockAltRepository());
            _JsonLDService = new JsonLDService(new MockJsonLDRepository());

            var imageDatas = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas.Add(new Infrastructure.Models.Data.Shared.Image.Image("", null, 0, false, false, "First", 0, null, null));
            imageDatas.Add(new Infrastructure.Models.Data.Shared.Image.Image("", null, 1, false, false, "Second", 1, null, null));
            imageDatas.Add(new Infrastructure.Models.Data.Shared.Image.Image("", null, 2, false, false, "Image03UIID", 2, null, null));
            imageDatas.Add(new Infrastructure.Models.Data.Shared.Image.Image("", null, 3, false, false, "Image04UIID", 3, null, null));

            List<Card> cardDatas0 = new List<Card>();
            cardDatas0.Add(new Card(imageDatas[0], "TitleCard00", "DescriptionCard00", "NavigationCard00", 0, false, false, 0, "First", 0, null));
            cardDatas0.Add(new Card(imageDatas[1], "TitleCard01", "DescriptionCard01", "NavigationCard01", 1, false, false, 1, "Second", 1, null));
            cardDatas0.Add(new Card(imageDatas[2], "TitleCard02", "DescriptionCard02", "NavigationCard02", 2, false, false, 2, "CardUIID13", 2, null));
            cardDatas0.Add(new Card(imageDatas[3], "TitleCard03", "DescriptionCard03", "NavigationCard03", 3, false, false, 3, "CardUIID14", 3, null));

            List<Card> cardDatas1 = new List<Card>();
            cardDatas1.Add(new Card(imageDatas[0], "TitleCard10", "DescriptionCard10", "NavigationCard10", 0, false, false, 0, "First", 0, null));
            cardDatas1.Add(new Card(imageDatas[1], "TitleCard11", "DescriptionCard11", "NavigationCard11", 1, false, false, 1, "Second", 1, null));
            cardDatas1.Add(new Card(imageDatas[2], "TitleCard12", "DescriptionCard12", "NavigationCard12", 2, false, false, 2, "CardUIID13", 2, null));
            cardDatas1.Add(new Card(imageDatas[3], "TitleCard13", "DescriptionCard13", "NavigationCard13", 3, false, false, 3, "CardUIID14", 3, null));

            List<Card> cardDatas2 = new List<Card>();
            cardDatas2.Add(new Card(imageDatas[0], "TitleCard20", "DescriptionCard20", "NavigationCard20", 0, false, false, 0, "First", 0, null));
            cardDatas2.Add(new Card(imageDatas[1], "TitleCard21", "DescriptionCard21", "NavigationCard21", 1, false, false, 1, "Second", 1, null));
            cardDatas2.Add(new Card(imageDatas[2], "TitleCard22", "DescriptionCard22", "NavigationCard22", 2, false, false, 2, "CardUIID13", 2, null));
            cardDatas2.Add(new Card(imageDatas[3], "TitleCard23", "DescriptionCard23", "NavigationCard23", 3, false, false, 3, "CardUIID14", 3, null));

            List<Card> cardDatas3 = new List<Card>();
            cardDatas3.Add(new Card(imageDatas[0], "TitleCard30", "DescriptionCard30", "NavigationCard30", 0, false, false, 0, "First", 0, null));
            cardDatas3.Add(new Card(imageDatas[1], "TitleCard31", "DescriptionCard31", "NavigationCard31", 1, false, false, 1, "Second", 1, null));
            cardDatas3.Add(new Card(imageDatas[2], "TitleCard32", "DescriptionCard32", "NavigationCard32", 2, false, false, 2, "CardUIID13", 2, null));
            cardDatas3.Add(new Card(imageDatas[3], "TitleCard33", "DescriptionCard33", "NavigationCard33", 3, false, false, 3, "CardUIID14", 3, null));

            List<Card> cardDatas4 = new List<Card>();
            cardDatas4.Add(new Card(imageDatas[0], "TitleCard40", "DescriptionCard40", "NavigationCard40", 0, false, false, 0, "First", 0, null));
            cardDatas4.Add(new Card(imageDatas[1], "TitleCard41", "DescriptionCard41", "NavigationCard41", 1, false, false, 1, "Second", 1, null));
            cardDatas4.Add(new Card(imageDatas[2], "TitleCard42", "DescriptionCard42", "NavigationCard42", 2, false, false, 2, "CardUIID13", 2, null));
            cardDatas4.Add(new Card(imageDatas[3], "TitleCard43", "DescriptionCard43", "NavigationCard43", 3, false, false, 3, "CardUIID14", 3, null));

            _carouselCards.Add(new CarouselCard(0,false,false,cardDatas0,0,"First",0));
            _carouselCards.Add(new CarouselCard(1, false, false, cardDatas1, 1, "Second", 1));
            _carouselCards.Add(new CarouselCard(2, false, false, cardDatas2, 2, "Non", 2));
            _carouselCards.Add(new CarouselCard(3, false, false, cardDatas3, 3, null, 3));
            _carouselCards.Add(new CarouselCard(4, false, false, cardDatas4, 4, "Multiple", 4));

        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void CarouselCard_Ctor(int Id)
        {
            //Arrange
            SetUp();
            var carouselCard = _carouselCards.Where(x => x.Id == Id).FirstOrDefault();

            //Act
            var carouselCardConcrete = new UIFactory.Factory.Concrete.CarouselCard.CarouselCard(carouselCard, _JsonLDService, _AltService);

            //Assert
            Assert.Equal(carouselCard, carouselCardConcrete.CarouselCardData);
            Assert.Equal(carouselCard.DisplayOrder, carouselCardConcrete.DisplayOrder);
            Assert.Equal(carouselCard.UIConcreteType, carouselCardConcrete.UIConcreteType);
            if (Id == 0)
            {
                Assert.Equal("First", carouselCardConcrete.Cards[0].Image.AltData.UIId);
                Assert.Equal("Second", carouselCardConcrete.Cards[1].Image.AltData.UIId);
                Assert.Equal("First", carouselCardConcrete.Cards[0].Image.JsonLDDatas[0].UIId);
                Assert.Equal("Second", carouselCardConcrete.Cards[1].Image.JsonLDDatas[0].UIId);
            }
            
            switch (Id)
            {
                case 0:
                    Assert.Equal("First", carouselCardConcrete.JsonLDDatas[0].UIId);
                    break;
                case 1:
                    Assert.Equal("Second", carouselCardConcrete.JsonLDDatas[0].UIId);
                    break;
                case 2:
                    Assert.Equal(0, carouselCardConcrete.JsonLDDatas.Count());
                    break;
                case 3:
                    Assert.Equal(null, carouselCardConcrete.JsonLDDatas[0].UIId);
                    break;
                case 4:
                    Assert.Equal("Multiple", carouselCardConcrete.JsonLDDatas[0].UIId);
                    Assert.Equal("Multiple", carouselCardConcrete.JsonLDDatas[1].UIId);
                    Assert.NotEqual(carouselCardConcrete.JsonLDDatas[0], carouselCardConcrete.JsonLDDatas[1]);

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
        public void CarouselCard_Ctor_NullJsonLDService (int Id)
        {
            //Arrange
            SetUp();
            var carouselCard = _carouselCards.Where(x => x.Id == Id).FirstOrDefault();

            //Act
            var carouselCardConcrete = new UIFactory.Factory.Concrete.CarouselCard.CarouselCard(carouselCard, null, _AltService);

            //Assert
            Assert.Equal(carouselCard, carouselCardConcrete.CarouselCardData);
            Assert.Equal(carouselCard.DisplayOrder, carouselCardConcrete.DisplayOrder);
            Assert.Equal(carouselCard.UIConcreteType, carouselCardConcrete.UIConcreteType);
            if (Id == 0)
            {
                Assert.Equal("First", carouselCardConcrete.Cards[0].Image.AltData.UIId);
                Assert.Equal("Second", carouselCardConcrete.Cards[1].Image.AltData.UIId);
                Assert.Null(carouselCardConcrete.Cards[0].Image.JsonLDDatas);
                Assert.Null(carouselCardConcrete.Cards[1].Image.JsonLDDatas);
            }

            switch (Id)
            {
                case 0:
                    Assert.Null(carouselCardConcrete.JsonLDDatas);
                    break;
                case 1:
                    Assert.Null(carouselCardConcrete.JsonLDDatas);
                    break;
                case 2:
                    Assert.Null(carouselCardConcrete.JsonLDDatas);
                    break;
                case 3:
                    Assert.Null(carouselCardConcrete.JsonLDDatas);
                    break;
                case 4:
                    Assert.Null(carouselCardConcrete.JsonLDDatas);
                    break;

            }
            TearDown();
        }

        [Theory]
        [InlineData(0)]
        public void CarouselCard_Ctor_NullAltService(int Id)
        {
            //Arrange
            SetUp();
            var carouselCard = _carouselCards.Where(x => x.Id == Id).FirstOrDefault();

            //Act
            var carouselCardConcrete = new UIFactory.Factory.Concrete.CarouselCard.CarouselCard(carouselCard, _JsonLDService, null);

            //Assert
            Assert.Equal(carouselCard, carouselCardConcrete.CarouselCardData);
            Assert.Equal(carouselCard.DisplayOrder, carouselCardConcrete.DisplayOrder);
            Assert.Equal(carouselCard.UIConcreteType, carouselCardConcrete.UIConcreteType);
            if (Id == 0)
            {
                Assert.Null(carouselCardConcrete.Cards[0].Image.AltData);
                Assert.Null(carouselCardConcrete.Cards[1].Image.AltData);
                Assert.Equal("First", carouselCardConcrete.Cards[0].Image.JsonLDDatas[0].UIId);
                Assert.Equal("Second", carouselCardConcrete.Cards[1].Image.JsonLDDatas[0].UIId);
            }

            switch (Id)
            {
                case 0:
                    Assert.Equal("First", carouselCardConcrete.JsonLDDatas[0].UIId);
                    break;
            }
            TearDown();
        }

        public void TearDown()
        {
            _carouselCards = null;
            _AltService = null;
            _JsonLDService = null;
        }
    }
}

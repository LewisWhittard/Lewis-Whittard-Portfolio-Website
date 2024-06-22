﻿using SEO.Repository.AltRepository;
using SEO.Repository.JsonLDRepositoryRepository;
using SEO.Service.AltService;
using SEO.Service.JsonLDService;

namespace UIFactoryTests.Concrete

{
    public class CardTests
    {
        private AltService _altService;
        private JsonLDService _jsonLDService;
        private List<Infrastructure.Models.Data.Shared.Card.Card> _cardDatas;

        public void SetUp()
        {
            _altService = new AltService(new MockAltRepository());
            _jsonLDService = new JsonLDService(new MockJsonLDRepository());
            _cardDatas = new List<Infrastructure.Models.Data.Shared.Card.Card>();

            var imageDatas = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas.Add(new Infrastructure.Models.Data.Shared.Image.Image("", null, 0, false, false, "First", null, 0, null));
            imageDatas.Add(new Infrastructure.Models.Data.Shared.Image.Image("", null, 1, false, false, "Second", null, 1, null));
            imageDatas.Add(new Infrastructure.Models.Data.Shared.Image.Image("", null, 2, false, false, "Image3GUID", null, 2, null));
            imageDatas.Add(new Infrastructure.Models.Data.Shared.Image.Image("", null, 3, false, false, "Image4GUID", null, 3, null));

            _cardDatas.Add(new Infrastructure.Models.Data.Shared.Card.Card(imageDatas[0], "TitleCard0", "DescriptionCard0", "NavigationCard0", 0, false, false, 0, "First", 0));
            _cardDatas.Add(new Infrastructure.Models.Data.Shared.Card.Card(imageDatas[1], "TitleCard1", "DescriptionCard1", "NavigationCard1", 1, false, false, 1, "Second", 1));
            _cardDatas.Add(new Infrastructure.Models.Data.Shared.Card.Card(imageDatas[2], "TitleCard2", "DescriptionCard2", "NavigationCard2", 2, false, false, 2, "Non", 2));
            _cardDatas.Add(new Infrastructure.Models.Data.Shared.Card.Card(imageDatas[3], "TitleCard3", "DescriptionCard3", "NavigationCard3", 3, false, false, 3, null, 3));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Card_Ctor(int Id)
        {
            SetUp();

            //Arrange
            var card = _cardDatas.Where(x => x.Id == Id).FirstOrDefault();
            //act
            var cardConcrete = new UIFactory.Factory.Concrete.Shared.Card.Card(card, _altService, _jsonLDService);

            //Assert
            Assert.NotNull(cardConcrete.CardData);
            Assert.Equal(card, cardConcrete.CardData);
            Assert.Equal(card.DisplayOrder, cardConcrete.DisplayOrder);
            Assert.Equal(card.UIConcreteType, cardConcrete.UIConcreteType);
            if (Id == 0)
            {
                Assert.Equal("First", cardConcrete.Image.AltData.SuperClassGUID);
            }
            switch (Id)
            {
                case 0:
                    Assert.Equal("First", cardConcrete.JsonLDs[0].SuperClassGUID);
                    break;
                case 1:
                    Assert.Equal("Second", cardConcrete.JsonLDs[0].SuperClassGUID);
                    break;
                case 2:
                    Assert.Equal(0, cardConcrete.JsonLDs.Count());
                    break;
                case 3:
                    Assert.Equal(0, cardConcrete.JsonLDs.Count());
                    break;
                case 4:
                    Assert.Equal("Multiple", cardConcrete.JsonLDs[0].SuperClassGUID);
                    Assert.Equal("Multiple", cardConcrete.JsonLDs[1].SuperClassGUID);
                    break;
            }

            TearDown();
        }

        public void TearDown()
        {
            _altService = null;
            _jsonLDService = null;
        }

    }
}

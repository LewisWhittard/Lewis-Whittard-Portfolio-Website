using Infrastructure.Models.Data.Interface;
using SEO.Service.AltService;
using SEO.Service.JsonLDService;
using UIFactory.Factory.Concrete.CarouselCard.Interface;
using UIFactory.Factory.Concrete.Interface;

namespace UIFactory.Factory.Concrete.CarouselCard
{
    public class CarouselCard : ICarouselCard, IConcreteUI
    {
        public Infrastructure.Models.Data.CarouselCard.CarouselCard CarouselCardData { get; private set; }
        public List<SEO.Model.JsonLD.JsonLDData>? JsonLDDatas { get; private set; }
        public List<Shared.Card.Card> Cards { get; private set; }
        public int? DisplayOrder { get; private set; }
        public UIConcrete UIConcreteType { get; private set; }

        private readonly Infrastructure.Models.Data.CarouselCard.CarouselCard _carouselCardDatas;
        private readonly JsonLDService? _jsonLDService;
        private readonly AltService? _altService;

        public CarouselCard(Infrastructure.Models.Data.CarouselCard.CarouselCard carouselCardDatas, JsonLDService? jsonLDService, AltService altService)
        {
            _carouselCardDatas = carouselCardDatas;
            CarouselCardData = _carouselCardDatas;
            _jsonLDService = jsonLDService;
            _altService = altService;
            SetJsonLD();
            SetCards();
            DisplayOrder = (int)_carouselCardDatas.DisplayOrder;
            UIConcreteType = (UIConcrete)_carouselCardDatas.UIConcreteType;
        }

        public void SetCards()
        {
            Cards = new List<Shared.Card.Card>();
            foreach (var card in _carouselCardDatas.Cards)
            {
                Cards.Add(new Shared.Card.Card(card, _altService, _jsonLDService));
            }
        }

        public void SetJsonLD()
        {
            if (_jsonLDService != null)
            {
                JsonLDDatas = _jsonLDService.GetBySuperClassGUID(CarouselCardData.GUID, false);
            }
            else
            {
                JsonLDDatas = null;
            }
        }


    }
}

using SEO.Model.JsonLD;
using SEO.Service.AltService;
using SEO.Service.JsonLDService;
using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Concrete.Shared.Card.Interface;

namespace UIFactory.Factory.Concrete.Shared.Card
{
    internal class Card : ICard, IConcrete
    {
        public Image.Image Image { get; private set; }
        public List<JsonLDData>? JsonLDs { get; private set; }
        public Infrastructure.Models.Data.Shared.Card.Card CardData { get; private set; }

        private readonly Infrastructure.Models.Data.Shared.Card.Card _card;
        private readonly JsonLDService? _jsonLDService;
        private readonly AltService? _altService;

        public Card(Infrastructure.Models.Data.Shared.Card.Card card, AltService altService, JsonLDService? jsonLDService)
        {
            _card = card;
            CardData = _card;
            _jsonLDService = jsonLDService;
            _altService = altService;
            SetJsonLDData();
            Image = new Image.Image(_card.Image, _altService, _jsonLDService);
        }

        
        private void SetJsonLDData()
        {
            if (_jsonLDService != null)
            {
                JsonLDs = _jsonLDService.GetBySuperClassGUID(CardData.GUID, false);
            }
            else
            {
                JsonLDs = null;
            }

        }
    }
}

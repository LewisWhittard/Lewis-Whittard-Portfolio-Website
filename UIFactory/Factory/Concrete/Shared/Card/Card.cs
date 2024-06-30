using Infrastructure.Models.Data.Interface;
using SEO.Model.JsonLD;
using SEO.Service.AltService;
using SEO.Service.JsonLDService;
using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Concrete.Shared.Card.Interface;

namespace UIFactory.Factory.Concrete.Shared.Card
{
    public class Card : ICard, IConcreteUI
    {
        public Image.Image Image { get; private set; }
        public List<JsonLDData>? JsonLDDatas { get; private set; }
        public Infrastructure.Models.Data.Shared.Card.Card CardData { get; private set; }
        public int? DisplayOrder { get; private set; }
        public UIConcrete UIConcreteType { get; private set; }


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
            DisplayOrder = (int)_card.DisplayOrder;
            UIConcreteType = (UIConcrete)_card.UIConcreteType;
        }

        
        private void SetJsonLDData()
        {
            if (_jsonLDService != null)
            {
                JsonLDDatas = _jsonLDService.GetBySuperClassUIID(CardData.UIID, false);
            }
            else
            {
                JsonLDDatas = null;
            }

        }
    }
}

using SEO.Models.Alt.Interface;
using SEO.Models.JsonLD.Interface;
using UIFactory.Factory.CSHTML.Concrete.Card.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.Card
{
    public class Card : ICard, ICSHTML, IUI
    {
        public Image Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
        public int? DisplayOrder { get; set; }
        public UI? UIType { get; set; }
        public string GUID { get; set; }

        private readonly Infrastructure.Models.Data.Shared.Card.Card _card;

        public Card(Infrastructure.Models.Data.Shared.Card.Card card, List<IJsonLDData> jsonLDData, List<IAltData> altData)
        {
            _card = card;
            Image = new Image(_card.Image, altData.Where(x => x.GUID == _card.GUID).FirstOrDefault());
            Title = _card.Title;
            Description = _card.Description;
            Navigation = _card.Navigation;
            DisplayOrder = _card.DisplayOrder;
            UIType = UI.Card;
            GUID = _card.GUID;
        }
    }
}

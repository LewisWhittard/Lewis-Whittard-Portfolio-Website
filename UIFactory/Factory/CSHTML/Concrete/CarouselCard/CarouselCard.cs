using SEO.Models.Alt.Interface;
using SEO.Models.JsonLD.Interface;
using UIFactory.Factory.CSHTML.Concrete.CarouselCard.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.CarouselCard
{
    public class CarouselCard : ICarouselCard, ICSHTML, IJsonLD, IUI
    {
        public List<Card> Cards { get; set; }
        public int? DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
        public UI? UIType { get; set; }
        public string GUID { get; set; }

        private Infrastructure.Models.Data.CarouselCard.CarouselCard _carouselCard;
        private readonly List<IAltData> _alt;
        

        public CarouselCard(Infrastructure.Models.Data.CarouselCard.CarouselCard carouselCard, List<IJsonLDData> jsonLD, List<IAltData> alt)
        {
            _carouselCard = carouselCard;
            _alt = alt;
            foreach (var item in _carouselCard.Cards)
            {
                Cards.Add(new Card(item, _alt.Where(x => x.GUID == item.GUID).FirstOrDefault()));
            }

            int cardCount = Cards.Count();
            if (cardCount < 9) 
            {
                List<Card> cards = PopulateBlankCards(cardCount);
            }

            DisplayOrder = _carouselCard.DisplayOrder;
            UIType = UI.CarouselCard;
            GUID = _carouselCard.GUID;
        }

        private List<Card> PopulateBlankCards(int cardCount)
        {
            List<Card> blankCards = new List<Card>();
            int cardsRequired = 9 - cardCount;

            for (int i = 0; i < cardsRequired; i++)
            {
                Card card = new Card();
            }

            return null;
        }
    }
}

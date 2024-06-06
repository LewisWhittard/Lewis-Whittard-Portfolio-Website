using SEO.Models.Alt.Interface;
using SEO.Models.JsonLD.Interface;
using UIFactory.Factory.Concrete.CarouselCard.Interfaces;
using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.Concrete.CarouselCard
{
    public class CarouselCard : ICarouselCard, ICSHTML, IJsonLD, IUI
    {
        public List<Card> Cards { get; private set; }
        public int? DisplayOrder { get; private set; }
        public List<string> JsonLDValues { get; private set; }
        public UI? UIType { get; private set; }
        public string GUID { get; private set; }

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
                Cards.AddRange(cards);
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
                blankCards.Add(card);
            }

            return blankCards;
        }

        public List<List<Card>> ReturnCardsAsRows()
        {
            var cards = Cards.OrderByDescending(x => x.DisplayOrder).ToList();

            List<List<Card>> Result = new List<List<Card>>();
            List<Card> rowOne = new List<Card> { cards[0], cards[1], cards[2] };
            List<Card> rowTwo = new List<Card> { cards[3], cards[4], cards[5] };
            List<Card> rowThree = new List<Card> { cards[6], cards[7], cards[8] };
            Result.Add(rowOne);
            Result.Add(rowTwo);
            Result.Add(rowThree);

            return Result;
        }
    }
}

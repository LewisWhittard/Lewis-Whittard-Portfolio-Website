using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Page.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Page
{
    public class Page : IPage, IData
    {
        public string PageName { get; private set; }
        public Head.Head? Head { get; private set; }
        public List<Shared.Card.Card>? Cards { get; private set; }
        public List<Carousel.Carousel>? Carousels { get; private set; }
        public List<CarouselCard.CarouselCard>? CarouselCards { get; private set; }
        public List<InformationBlock.InfomatonBlock>? InformationBlocks { get; private set; }
        public List<Video.Video>? Videos { get; private set; }
        public List<Table.Table>? Tables { get; private set; }
        public string GUID { get; private set; }
        public int Id { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; private set; }
        public int? DisplayOrder { get; private set; }

        public Page()
        {
            UIConcreteType = UIConcrete.Page;
        }

        public Page(string pageName, List<Shared.Card.Card>? cards,Head.Head? head, List<Carousel.Carousel>? carousels, List<CarouselCard.CarouselCard>? carouselCard, List<InformationBlock.InfomatonBlock>? informationBlocks, List<Table.Table>? tables, List<Video.Video>? videos, string gUID, int id, bool deleted, bool inactive)
        {
            Id = id;
            PageName = pageName;
            Head = head;
            Cards = cards;
            Carousels = carousels;
            CarouselCards = carouselCard;
            InformationBlocks = informationBlocks;
            Tables = tables;
            Videos = videos;
            GUID = gUID;
            Deleted = deleted;
            Inactive = inactive;
            UIConcreteType = UIConcrete.Page;
        }

        public List<IData> CreateIDataList()
        {
            List<IData> result = new List<IData>();

            if (Cards?.Count() > 0)
            {
                result.AddRange(Cards.ToList().ConvertAll(x => (IData)x));
            }

            if (Carousels?.Count() > 0)
            {
                result.AddRange(Carousels.ToList().ConvertAll(x => (IData)x));
            }

            if (CarouselCards?.Count() > 0)
            {
                result.AddRange(CarouselCards.ToList().ConvertAll(x => (IData)x));
            }

            if (InformationBlocks?.Count() > 0)
            {
                result.AddRange(InformationBlocks.ToList().ConvertAll(x => (IData)x));
            }

            if (Tables?.Count() > 0)
            {
                result.AddRange(Tables.ToList().ConvertAll(x => (IData)x));
            }

            if (Videos?.Count() > 0)
            {
                result.AddRange(Videos.ToList().ConvertAll(x => (IData)x));
            }

            return result;
        }
    }
}

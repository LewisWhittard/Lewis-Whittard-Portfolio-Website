using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Page.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Page
{
    public class Page : IPage, IData
    {
        public string PageName { get; set; }
        public List<Card.Card> Cards { get; set; }
        public List<Carousel.Carousel> Carousels { get; set; }
        public List<CarouselCard.Card> CarouselCards { get; set; }
        public List<InfomationBlock.InfomatonBlock> InfomationBlocks { get; set; }
        public List<Table.Table> Tables { get; set; }
        public string GUID { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; set; }

        public Page()
        {
            
        }

        public List<IData> CreateIDataList()
        {
            List<IData> result = new List<IData>();
            result.Add((IData)Cards);
            result.Add((IData)Carousels);
            result.Add((IData)CarouselCards);
            result.Add((IData)InfomationBlocks);
            result.Add((IData)Tables);

            return result;
        }
    }
}

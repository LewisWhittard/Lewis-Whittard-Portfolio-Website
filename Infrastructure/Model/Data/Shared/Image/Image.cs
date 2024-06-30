using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Image.Interfaces;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Shared.Image
{
    public class Image : IImage, IData
    {
        public string Source { get; private set; }
        public int? DisplayOrder { get; private set; }
        public int Id { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public string UIID { get; private set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; private set; }
        public int? InformationBlockId { get; private set; }
        public int? CardId { get; private set; }
        public int? CarouselId { get; private set; }

        public Image()
        {
            UIConcreteType = UIConcrete.Image;
        }

        public Image(string source, int? displayOrder, int iD, bool deleted, bool inactive, string uIId, int? cardId, int? informationBlockId, int? carouselId)
        {
            Source = source;
            DisplayOrder = displayOrder;
            Id = iD;
            Deleted = deleted;
            Inactive = inactive;
            UIID = uIId;
            UIConcreteType = UIConcrete.Image;
            CardId = cardId;
            InformationBlockId = informationBlockId;
            CarouselId = carouselId;

        }
    }
}

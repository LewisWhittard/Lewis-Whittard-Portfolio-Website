using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Image.Interfaces;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Shared.Image
{
    public class Image : IImage, IData
    {
        public string Source { get; set; }
        public int? DisplayOrder { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public string GUID { get; set; }

        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; set; }
        public int? InformationBlockId { get; set; }
        public int? CardId { get; set; }
        public int? CarouselId { get; set; }

        public Image()
        {
            UIConcreteType = UIConcrete.Image;
        }

        public Image(string source, int? displayOrder, int iD, bool deleted, bool inactive, string gUID,int? cardId, int? informationBlockId, int? carouselId)
        {
            Source = source;
            DisplayOrder = displayOrder;
            Id = iD;
            Deleted = deleted;
            Inactive = inactive;
            GUID = gUID;
            UIConcreteType = UIConcrete.Image;
            CardId = cardId;
            InformationBlockId = informationBlockId;
            CarouselId = carouselId;

        }
    }
}

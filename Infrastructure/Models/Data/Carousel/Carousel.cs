using Infrastructure.Models.Data.Carousel.Interfaces;
using Infrastructure.Models.Data.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Carousel
{
    public class Carousel : ICarousel, IData
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public List<Shared.Image.Image> Images { get; set; }
        public int? DisplayOrder { get; set; }
        public int PageId { get; set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; set; }
        public string GUID { get; set; }

        public Carousel()
        {
            UIConcreteType = UIConcrete.Carousel;
        }

        public Carousel(int id, bool deleted, bool inactive, List<Shared.Image.Image> images, int? displayOrder, string gUID, int pageId)
        {
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            Images = images;
            DisplayOrder = displayOrder;
            UIConcreteType = UIConcrete.Carousel;
            GUID = gUID;
            PageId = pageId;
        }
    }
}

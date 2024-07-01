using Infrastructure.Models.Data.Carousel.Interfaces;
using Infrastructure.Models.Data.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Carousel
{
    public class Carousel : ICarousel, IData
    {
        public int Id { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public List<Shared.Image.Image> Images { get; private set; }
        public int? DisplayOrder { get; private set; }
        public int PageId { get; private set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; private set; }
        public string UIId { get; private set; }

        public Carousel()
        {
            UIConcreteType = UIConcrete.Carousel;
        }

        public Carousel(int id, bool deleted, bool inactive, List<Shared.Image.Image> images, int? displayOrder, string uIId, int pageId)
        {
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            Images = images;
            DisplayOrder = displayOrder;
            UIConcreteType = UIConcrete.Carousel;
            UIId = uIId;
            PageId = pageId;
        }
    }
}

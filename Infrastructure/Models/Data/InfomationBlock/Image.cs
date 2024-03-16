using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Interfaces.CarouselCard.Interfaces;

namespace Infrastructure.Models.Data.InfomationBlock
{
    public class Image : IImage, IData
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
    }
}

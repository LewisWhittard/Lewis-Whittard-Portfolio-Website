using Infrastructure.Models.Data.Card.Interfaces;
using Infrastructure.Models.Data.Interface;

namespace Infrastructure.Models.Data.Card
{
    public class Image : IImage, IData
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public UIConcreate? UIConcreateType { get; set; }
    }
}

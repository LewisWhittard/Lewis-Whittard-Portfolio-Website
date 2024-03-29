using Infrastructure.Models.Data.CarouselCard.Interfaces;
using Infrastructure.Models.Data.Interface;

namespace Infrastructure.Models.Data.CarouselCard
{
    public class Navigation : IData, INavigation
    {

        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public string Value { get; set; }
        public UIConcreate? UIConcreate { get; set; }
    }
}

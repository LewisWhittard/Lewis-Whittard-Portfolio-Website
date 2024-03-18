using UIFactory.Concreate.CSHTML.CarouselCard.Interfaces;
using UIFactory.Data.HTML.Interface;

namespace UIFactory.Concreate.CSHTML.CarouselCard
{
    public class Navigation : IData, INavigation
    {

        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public string Value { get; set; }
    }
}

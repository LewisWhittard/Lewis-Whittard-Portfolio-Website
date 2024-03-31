using UIFactory.Factory.Concreate.CSHTML.CarouselCard.Interfaces;

namespace UIFactory.Factory.Concreate.CSHTML.CarouselCard
{
    public class Navigation : INavigation
    {

        public int Id { get; set; }
        public string Value { get; set; }

        public Navigation(Infrastructure.Models.Data.CarouselCard.Navigation navigation)
        {
            Id = navigation.Id;
            Value = navigation.Value;
        }
    }
}

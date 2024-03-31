using UIFactory.Factory.Concreate.CSHTML.Card.Interfaces;

namespace UIFactory.Factory.Concreate.CSHTML.Card
{
    public class Navigation : INavigation
    {

        public int Id { get; set; }
        public string Value { get; set; }

        public Navigation(Infrastructure.Models.Data.Card.Navigation navigation)
        {
            Id = navigation.Id;
            Value = navigation.Value;
        }
    }
}

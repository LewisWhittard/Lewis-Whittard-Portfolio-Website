using SEO.Model.JsonLD;

namespace UIFactory.Factory.Concrete.Shared.Card.Interface
{
    public interface ICard
    {
        Infrastructure.Models.Data.Shared.Card.Card CardData { get; }
        Image.Image Image { get; }
        List<JsonLDData>? JsonLDs { get; }
    }
}

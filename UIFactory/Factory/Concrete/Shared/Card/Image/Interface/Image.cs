namespace UIFactory.Factory.Concrete.Shared.Card.Image.Interface
{
    public interface IImage
    {
        Infrastructure.Models.Data.Shared.Image.Image ImageData { get; }
        SEO.Models.Alt.AltData? AltData { get; }
        List<SEO.Models.JsonLD.JsonLDData>? TitleData { get; }
    }
}

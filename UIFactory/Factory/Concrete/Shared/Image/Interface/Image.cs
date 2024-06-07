namespace UIFactory.Factory.Concrete.Shared.Image.Interface
{
    public interface IImage
    {
        Infrastructure.Models.Data.Shared.Image.Image ImageData { get; }
        SEO.Models.Alt.AltData? AltData { get; }
        List<SEO.Models.JsonLD.JsonLDData>? JsonLDs { get; }
    }
}

namespace UIFactory.Factory.Concrete.Shared.Image.Interface
{
    public interface IImage
    {
        Infrastructure.Models.Data.Shared.Image.Image ImageData { get; }
        SEO.Model.Alt.AltData? AltData { get; }
        List<SEO.Model.JsonLD.JsonLDData>? JsonLDDatas { get; }
    }
}

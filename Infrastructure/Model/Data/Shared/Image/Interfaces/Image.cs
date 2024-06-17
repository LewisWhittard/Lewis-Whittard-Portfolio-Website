namespace Infrastructure.Models.Data.Shared.Image.Interfaces
{
    public interface IImage
    {
        string Source { get; }
        int? InformationBlockId { get; }
        int? CardId { get; }
        int? CarouselId { get; }
    }
}

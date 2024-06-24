namespace Infrastructure.Models.Data.Shared.Card.Interfaces
{
    public interface ICard
    {
        Image.Image Image { get; }
        string Title { get; }
        string Description { get; }
        string Navigation { get; }
        int? PageId { get; }
        int? CarouselCardId { get; }
    }
}

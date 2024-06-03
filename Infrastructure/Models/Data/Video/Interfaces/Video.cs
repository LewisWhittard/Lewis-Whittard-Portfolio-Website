namespace Infrastructure.Models.Data.Video.Interfaces
{
    public interface IVideo
    {
        string Source { get; }
        string Title { get; }
        string Description { get; }
        string Navigation { get; }
        int PageId { get; }
    }
}

namespace Infrastructure.Models.Data.Video.Interfaces
{
    public interface IVideo
    {
        public string Source { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
    }
}

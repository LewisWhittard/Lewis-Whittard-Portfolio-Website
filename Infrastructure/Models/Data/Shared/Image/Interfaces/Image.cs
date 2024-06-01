namespace Infrastructure.Models.Data.Shared.Image.Interfaces
{
    public interface IImage
    {
        public string Source { get; set; }
        public int? InformationBlockId { get; set; }
        public int? CardId { get; set; }
        public int? CarouselId { get; set; }
    }
}

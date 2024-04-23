namespace Infrastructure.Models.Data.Shared.Card.Interfaces
{
    public interface ICard
    {
        public Image.Image Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
    }
}

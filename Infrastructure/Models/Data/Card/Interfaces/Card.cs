namespace Infrastructure.Models.Data.Card.Interface
{
    public interface ICard
    {
        public Image Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Navigation Navigation { get; set; }
        public int DisplayOrder { get; set; }
    }
}

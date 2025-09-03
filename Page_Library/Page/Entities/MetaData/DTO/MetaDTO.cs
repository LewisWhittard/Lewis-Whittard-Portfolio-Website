namespace Page_Library.Page.Entities.MetaData.DTO
{
    public class MetaDTO
    {
        public string MetaTitle { get; set; }           // Always expected
        public string MetaDescription { get; set; }     // Always expected
        public List<string> MetaKeywords { get; set; }  // Always expected
        public int? MetaImageId { get; set; }           // Optional (nullable)
    }
}
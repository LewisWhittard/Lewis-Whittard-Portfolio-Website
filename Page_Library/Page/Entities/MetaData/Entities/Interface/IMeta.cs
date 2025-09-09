namespace Page_Library.Page.Entities.MetaData.Entities.DTO
{
    public interface IMeta
    {
        public string MetaTitle { get; }           // Always expected
        public string MetaDescription { get; }     // Always expected
        public List<string> MetaKeywords { get; }  // Always expected
        public int? MetaImageId { get;}           // Optional (nullable)

    }
}
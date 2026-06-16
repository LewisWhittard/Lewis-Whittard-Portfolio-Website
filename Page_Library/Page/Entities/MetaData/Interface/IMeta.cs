namespace Page_Library.Page.Entities.MetaData.Interface
{
    public interface IMeta
    {
        public string MetaTitle { get; }           // Always expected
        public string MetaDescription { get; }     // Always expected
        public List<string> MetaKeywords { get; }  // Always expected
        public string MetaImageUrl { get; }
        public string MetaImageAlt { get; }
    }
}

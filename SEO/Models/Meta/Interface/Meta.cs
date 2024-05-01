namespace SEO.Models.Meta.Interface
{
    public interface IMetaData
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public string Content { get; set; }
        public string GUID { get; set; }
        public string? Charset { get; set; }
        public string PageName { get; set; }
    }
}

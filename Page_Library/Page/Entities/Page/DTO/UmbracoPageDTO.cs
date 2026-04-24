namespace Page_Library.Page.Entities.Page.DTO
{
    public class UmbracoPageDto
    {
        public string ContentType { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime PublishDate { get; set; }
        public string Id { get; set; }
        public PropertiesDto Properties { get; set; }
        public string Category { get; set; }
        public string PageType { get; set; }
        public BlockGridDto ContentBlocks { get; set; }
        public Dictionary<string, object> Cultures { get; set; }
        public string Author { get; set; }
    }

    public class PropertiesDto
    {
        public MetaBlockGridDto Meta { get; set; }
    }

    public class MetaBlockGridDto
    {
        public List<BlockGridItemDto> Items { get; set; }
    }

    public class BlockGridDto
    {
        public int GridColumns { get; set; }
        public List<BlockGridItemDto> Items { get; set; }
    }

    public class BlockGridItemDto
    {
        public BlockContentDto Content { get; set; }
    }

    public class BlockContentDto
    {
        public string ContentType { get; set; }
        public string Id { get; set; }
    }

    public class BlockPropertiesDto
    {
        // META BLOCK
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public int? MetaImageId { get; set; }

        // HEADER BLOCK
        public string BlockType { get; set; }
        public string HLevel { get; set; }
        public string Alignment { get; set; }
        public string Text { get; set; }
    }

}

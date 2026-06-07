namespace Page_Library.Page.Entities.ContentBlock.DTO
{
    public class ContentBlockDTO
    {
        public string BlockType { get; set; } // e.g., Header, Paragraph, Image, Video, Hyperlink
        public string Alignment { get; set; } // e.g., Center, Left, Right

        // Header
        public string? Level { get; set; }     // Only for Header blocks (e.g., H1, H2, H3)
        public string? Text { get; set; }      // For Header blocks

        // Paragraph
        public string? BodyText { get; set; }  // For Paragraph blocks

        // Legacy media
        public int? MediaId { get; set; }      // For Image or Video blocks

        // Hyperlink
        public string? Url { get; set; }       // For Hyperlink blocks
        public string? LinkText { get; set; }  // For Hyperlink blocks

        // NEW: Image fields (Umbraco Delivery API v2)
        public string? ImageUrl { get; set; }
        public string? Alt { get; set; }

        // NEW: Video fields (Umbraco Delivery API v2)
        public string? VideoUrl { get; set; }
        public string? ThumbnailUrl { get; set; }

        // NEW: Video description
        public string? Description { get; set; }
    }
}

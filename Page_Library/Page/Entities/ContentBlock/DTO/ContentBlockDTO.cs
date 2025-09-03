namespace Page_Library.Page.Entities.ContentBlock.DTO
{
    public class ContentBlockDTO
    {
        public string BlockType { get; set; } // e.g., Header, Paragraph, Image, Video, Hyperlink
        public string Alignment { get; set; } // e.g., Center, Left, Right
        public string? Level { get; set; }     // Only for Header blocks (e.g., H1, H2, H3)
        public string? Text { get; set; }      // For Header blocks
        public string? BodyText { get; set; }  // For Paragraph blocks
        public int? MediaId { get; set; }     // For Image or Video blocks
        public string? AltText { get; set; }   // For Image blocks
        public string? Caption { get; set; }   // For Video blocks
        public string? Url { get; set; }       // For Hyperlink blocks
        public string? LinkText { get; set; }  // For Hyperlink blocks
    }
}
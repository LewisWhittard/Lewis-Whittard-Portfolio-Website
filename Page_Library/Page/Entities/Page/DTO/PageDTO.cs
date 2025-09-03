using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.MetaData.DTO;

public class PortfolioEntryDTO
{
    public int externalId { get; set; }
    public string title { get; set; }
    public string publishDate { get; set; }
    public MetaDTO meta { get; set; }
    public List<ContentBlockDTO> contentBlocks { get; set; }
}



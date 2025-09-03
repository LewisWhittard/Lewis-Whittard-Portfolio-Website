using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.MetaData.DTO;

public class PortfolioEntryDTO
{
    public int ExternalId { get; set; }
    public string Title { get; set; }
    public string PublishDate { get; set; }
    public MetaDTO Meta { get; set; }
    public List<ContentBlockDTO> ContentBlocks { get; set; }
}



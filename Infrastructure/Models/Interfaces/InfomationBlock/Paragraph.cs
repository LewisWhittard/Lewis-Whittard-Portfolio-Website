namespace Infrastructure.Models.Interfaces.InfomationBlock
{
    public interface IParagraph
    {
        public string Text { get; set; }
        public int DisplayOrder { get; set; }
        public int InfomationBlockid { get; set; }
    }
}

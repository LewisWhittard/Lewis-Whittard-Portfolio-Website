namespace Infrastructure.Models.Interfaces.InfomationBlock
{
    public interface IHeading
    {
        public string Text { get; set; }
        public int DisplayOrder { get; set; }
        public int InfomationBlockid { get; set; }
    }
}

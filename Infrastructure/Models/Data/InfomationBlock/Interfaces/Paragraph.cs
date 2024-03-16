

namespace Infrastructure.Models.Data.InfomationBlock.Interfaces
{
    public interface IParagraph
    {
        public string Text { get; set; }
        public int DisplayOrder { get; set; }
        public int InfomationBlockid {  get; set; }
    }
}

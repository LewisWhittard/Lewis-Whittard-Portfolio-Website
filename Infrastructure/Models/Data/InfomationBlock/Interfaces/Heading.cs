namespace Infrastructure.Models.Data.InformationBlock.Interfaces
{
    public interface IHeading
    {
        public string Text { get; set; }
        public int InformationBlockid { get; set; }
        public int Level { get; set; }
    }
}

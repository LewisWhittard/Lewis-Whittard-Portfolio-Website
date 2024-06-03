namespace Infrastructure.Models.Data.InformationBlock.Interfaces
{
    public interface IHeading
    {
        string Text { get; }
        int InformationBlockid { get; }
        int Level { get; }
    }
}

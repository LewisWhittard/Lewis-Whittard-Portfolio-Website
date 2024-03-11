namespace Infrastructure.Models.DataStandards.Interface
{
    public interface IData
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
    }
}

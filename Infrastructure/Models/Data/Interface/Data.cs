namespace Infrastructure.Models.DataStandards.Interface
{
    public interface IData
    {
        public int id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
    }
}

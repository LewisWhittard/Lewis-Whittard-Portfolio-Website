namespace Infrastructure.Models.DataStandards.Interface
{
    public interface IData
    {
        public int ID { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public int DisplayOrder { get; set; }
    }
}

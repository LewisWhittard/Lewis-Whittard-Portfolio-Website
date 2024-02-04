namespace LMW_Infrastructure.Model
{
	public interface IContactForm
	{
		public int ID { get; set; }
		public bool Inactive { get; set; }
		public bool Deleted { get; set; }
	}
}

using LMW_Infrastructure.Model;
using LMW_Infrastructure.Model.ContactForm;
using LMW_Infrastructure.Model.Content;
using Microsoft.EntityFrameworkCore;


namespace LMW_Infrastructure.DatabaseConfig
{
	public class ApplicationContext : DbContext
	{
		public DbSet<ContactForm> ContactForm { get; set; }
		public DbSet<Content> Content { get; set; }
		public DbSet<JsonLD> JsonLDs { get; set; }
		public DbSet<MicroData> MicroData { get; set; }
		public DbSet<WebPage> WebPages { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(Config());
		}

		private string Config()
		{
			string server = "(localdb)\\MSSQLLocalDB";
			string database = "LMWDev";
			string userID = "";
			string password = "";
			return $"Server={server};Database={database};User Id={userID};Password={password};";
		}
	}
}
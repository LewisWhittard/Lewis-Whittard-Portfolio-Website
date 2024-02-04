using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using LMW_Infrastructure.Model.ContactForm;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Identity.Client;

public class ApplicationContext : DbContext
{
	public DbSet<IContactForm> ContactForm { get; set; }
	public DbSet<Icontent> Content { get; set; }
	public DbSet<IJsonLD> JsonLDs { get; set; }
	public DbSet<IMicroData> MicroData { get; set; }
	public DbSet<IWebPage> WebPages { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server={server};Database={Database};User Id={UserId};Password={Password};");
	}
}
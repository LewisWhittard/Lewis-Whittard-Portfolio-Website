using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMW_Infrastructure.Model.ContactForm
{
	public class ContactForm : IContactForm, IDatabaseTableStandards
	{
		public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Inactive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	}
}

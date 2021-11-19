using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample.Model
{
	public class Client
	{
		public int ClientId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public List<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();

		public List<Address> Addresses { get; set; } = new List<Address>();
	}
}
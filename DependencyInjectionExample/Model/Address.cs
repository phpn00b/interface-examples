using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample.Model
{
	public class Address
	{
		public int AddressId { get; set; }

		public int ClientId { get; set; }

		public string Line1 { get; set; }

		public string Line2 { get; set; }

		public string City { get; set; }

		public string State { get; set; }

		public string Country { get; set; }
	}
}
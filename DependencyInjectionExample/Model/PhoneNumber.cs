using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample.Model
{
	public class PhoneNumber
	{
		public int PhoneNumberId { get; set; }

		public int ClientId { get; set; }

		public string Location { get; set; }

		public string Number { get; set; }
	}
}
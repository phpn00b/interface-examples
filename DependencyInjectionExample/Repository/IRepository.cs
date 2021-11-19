using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionExample.Model;

namespace DependencyInjectionExample
{
	public interface IRepository
	{
		void AddClient(Client client);

		void RemoveClient(int clientId);

		void UpdateClient(Client client);

		Client FetchClientById(int clientId);

		List<Client> FetchClients(ClientSearchParameters searchParameters);

		List<Client> FetchAllClients();

	}
}
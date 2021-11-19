using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionExample.Model;

namespace DependencyInjectionExample.Repository.Implementations
{
	public class InMemoryRepository : IRepository
	{
		private static int _nextId = 1;
		private static int _nextAddressId = 1;
		private static int _nextPhoneId = 1;

		private readonly List<Client> _clients = new List<Client>();
		#region Implementation of IRepository

		/// <inheritdoc />
		public void AddClient(Client client)
		{
			if (client.ClientId != 0)
			{
				// client id might be taken check for that 
				var existing = _clients.FirstOrDefault(o => o.ClientId == client.ClientId);
				if (existing != null)
					throw new ArgumentException($"client id {client.ClientId} already in use did you mean to do an update?");
			}
			else
			{
				client.ClientId = _nextId++;
				client.Addresses.ForEach(o =>
				{
					o.ClientId = client.ClientId;
					o.AddressId = _nextAddressId++;
				});
				client.PhoneNumbers.ForEach(o =>
				{
					o.ClientId = client.ClientId;
					o.PhoneNumberId = _nextPhoneId++;
				});
				_clients.Add(client);
			}
		}

		/// <inheritdoc />
		public void RemoveClient(int clientId)
		{
			var existing = _clients.FirstOrDefault(o => o.ClientId == clientId);
			_clients.Remove(existing);
		}

		/// <inheritdoc />
		public void UpdateClient(Client client)
		{
			var existing = _clients.FirstOrDefault(o => o.ClientId == client.ClientId);
			if (existing == null)
				throw new ArgumentException($"client id {client.ClientId} doesn't exist did you want to create it?");
			existing.FirstName = client.FirstName;
			existing.LastName = client.LastName;
			existing.Addresses = client.Addresses;
			existing.PhoneNumbers = client.PhoneNumbers;
		}

		/// <inheritdoc />
		public Client FetchClientById(int clientId)
		{
			var existing = _clients.FirstOrDefault(o => o.ClientId == clientId);
			return existing;
		}

		/// <inheritdoc />
		public List<Client> FetchClients(ClientSearchParameters searchParameters)
		{
			var results = _clients as IEnumerable<Client>;
			if (!string.IsNullOrWhiteSpace(searchParameters.FirstName))
				results = results.Where(o => o.FirstName.ToLower().Contains(searchParameters.FirstName.ToLower()));
			if (!string.IsNullOrWhiteSpace(searchParameters.LastName))
				results = results.Where(o => o.LastName.ToLower().Contains(searchParameters.LastName.ToLower()));
			return results.ToList();
		}

		/// <inheritdoc />
		public List<Client> FetchAllClients()
		{
			return _clients;
		}

		#endregion
	}
}
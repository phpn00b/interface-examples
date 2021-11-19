using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionExample.Model;
using ServiceStack;

namespace DependencyInjectionExample.Repository.Implementations
{
	public class FileRepository : IRepository
	{
		private static readonly string _path = $"{AppDomain.CurrentDomain.BaseDirectory}db{Path.DirectorySeparatorChar}clients{Path.DirectorySeparatorChar}";
		private static int _nextId = 1;
		private static int _nextAddressId = 1;
		private static int _nextPhoneId = 1;
		public FileRepository()
		{
			if (!Directory.Exists(_path))
			{
				Directory.CreateDirectory(_path);
				_nextId = 1;
				File.WriteAllText($"{_path}next-key", _nextId.ToString());
				File.WriteAllText($"{_path}next-key-address", _nextAddressId.ToString());
				File.WriteAllText($"{_path}next-key-phone", _nextPhoneId.ToString());
			}
			else
			{
				_nextId = Convert.ToInt32(File.ReadAllText($"{_path}next-key"));
				_nextAddressId = Convert.ToInt32(File.ReadAllText($"{_path}next-key-address"));
				_nextPhoneId = Convert.ToInt32(File.ReadAllText($"{_path}next-key-phone"));
			}

		}
		#region Implementation of IRepository

		/// <inheritdoc />
		public void AddClient(Client client)
		{
			if (client.ClientId != 0)
			{
				// client id might be taken check for that 
				var existing = InternalFetchClient(client.ClientId);
				if (existing != null)
					throw new ArgumentException($"client id {client.ClientId} already in use did you mean to do an update?");
			}
			else
			{
				client.Addresses.ForEach(o =>
				{
					o.ClientId = client.ClientId;
					o.AddressId = _nextAddressId++;
					File.WriteAllText($"{_path}next-key-address", _nextId.ToString());
				});
				client.PhoneNumbers.ForEach(o =>
				{
					o.ClientId = client.ClientId;
					o.PhoneNumberId = _nextPhoneId++;
					File.WriteAllText($"{_path}next-key-phone", _nextId.ToString());
				});
				client.ClientId = _nextId;
				InternalSaveClient(client);
				File.WriteAllText($"{_path}next-key", _nextId.ToString());
			}
		}

		/// <inheritdoc />
		public void RemoveClient(int clientId)
		{
			InternalRemoveClient(clientId);
		}

		/// <inheritdoc />
		public void UpdateClient(Client client)
		{
			var existing = InternalFetchClient(client.ClientId);
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
			var existing = InternalFetchClient(clientId);
			return existing;
		}

		/// <inheritdoc />
		public List<Client> FetchClients(ClientSearchParameters searchParameters)
		{
			var results = InternalFetchAllClients() as IEnumerable<Client>;
			if (!string.IsNullOrWhiteSpace(searchParameters.FirstName))
				results = results.Where(o => o.FirstName.ToLower().Contains(searchParameters.FirstName.ToLower()));
			if (!string.IsNullOrWhiteSpace(searchParameters.LastName))
				results = results.Where(o => o.LastName.ToLower().Contains(searchParameters.LastName.ToLower()));
			return results.ToList();
		}

		/// <inheritdoc />
		public List<Client> FetchAllClients()
		{
			return InternalFetchAllClients();
		}

		#endregion

		private void InternalSaveClient(Client client)
		{
			File.WriteAllText($"{_path}{client.ClientId}.json", client.ToJson());
		}

		private Client InternalFetchClient(int clientId)
		{
			string path = $"{_path}{clientId}.json";
			if (File.Exists(path))
				return File.ReadAllText(path).FromJson<Client>();
			return null;
		}

		private void InternalRemoveClient(int clientId)
		{
			if (File.Exists($"{_path}{clientId}.json"))
				File.Delete($"{_path}{clientId}.json");
		}

		private List<Client> InternalFetchAllClients()
		{
			var files = Directory.EnumerateFiles(_path, "*.json");
			List<Client> clients = new List<Client>();
			foreach (var file in files)
			{
				try
				{
					var id = Convert.ToInt32(file.Substring(_path.Length).Split('.'));
					clients.Add(InternalFetchClient(id));
				}
				catch (Exception e)
				{

				}
			}

			return clients;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using DependencyInjectionExample;
using DependencyInjectionExample.Model;

namespace API.Repository
{
	public class EntityFrameworkRepository : IRepository
	{
		private readonly ApplicationDbContext _db;


		public EntityFrameworkRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		#region Implementation of IRepository

		/// <inheritdoc />
		public void AddClient(Client client)
		{
			_db.Clients.Add(client);
			_db.SaveChanges();
		}

		/// <inheritdoc />
		public void RemoveClient(int clientId)
		{
			_db.PhoneNumbers.RemoveRange(_db.PhoneNumbers.Where(o => o.ClientId == clientId));
			_db.Addresses.RemoveRange(_db.Addresses.Where(o => o.ClientId == clientId));
			_db.Clients.Remove(_db.Clients.Find(clientId));
			_db.SaveChanges();
		}

		/// <inheritdoc />
		public void UpdateClient(Client client)
		{
			_db.Clients.Attach(client);
			_db.SaveChanges();
		}

		/// <inheritdoc />
		public Client FetchClientById(int clientId)
		{
			return _db.Clients.Find(clientId);
		}

		/// <inheritdoc />
		public List<Client> FetchClients(ClientSearchParameters searchParameters)
		{
			var results = _db.Clients as IQueryable<Client>;
			if (!string.IsNullOrWhiteSpace(searchParameters.FirstName))
				results = results.Where(o => o.FirstName.ToLower().Contains(searchParameters.FirstName.ToLower()));
			if (!string.IsNullOrWhiteSpace(searchParameters.LastName))
				results = results.Where(o => o.LastName.ToLower().Contains(searchParameters.LastName.ToLower()));
			return results.Include(o => o.Addresses).Include(o => o.PhoneNumbers).ToList();
		}

		/// <inheritdoc />
		public List<Client> FetchAllClients()
		{
			return _db.Clients.Include(o => o.Addresses).Include(o => o.PhoneNumbers).ToList();
		}

		#endregion
	}
}
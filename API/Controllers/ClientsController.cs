using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionExample;
using DependencyInjectionExample.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ClientsController : Controller
	{
		private readonly IRepository _repository;
		public ClientsController(IRepository repository)
		{
			_repository = repository;
		}

		#region Implementation of IRepository


		[HttpPost("add")]
		public Client AddClient(Client client)
		{
			_repository.AddClient(client);
			return client;
		}

		[HttpDelete("{clientId}")]
		public void RemoveClient(int clientId)
		{
			_repository.RemoveClient(clientId);
		}

		[HttpPost("update")]
		public void UpdateClient(Client client)
		{
			_repository.UpdateClient(client);
		}

		[HttpGet("{clientId}")]
		public Client FetchClientById(int clientId)
		{
			return _repository.FetchClientById(clientId);
		}

		[HttpPost("search")]
		public List<Client> FetchClients([FromBody] ClientSearchParameters searchParameters)
		{
			return _repository.FetchClients(searchParameters);
		}

		[HttpGet]
		public List<Client> FetchAllClients()
		{
			return _repository.FetchAllClients();
		}

		#endregion
	}
}
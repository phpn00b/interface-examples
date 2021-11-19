using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionExample.Model;
using RestSharp;
using ServiceStack;

namespace DependencyInjectionExample.Repository.Implementations
{
	public class ApiRepository : IRepository
	{
		private readonly string _serverUrl;
		private readonly RestClient _client;
		public ApiRepository(string serverUrl)
		{
			_serverUrl = serverUrl;
			_client = new RestClient(serverUrl);
		}
		#region Implementation of IRepository

		/// <inheritdoc />
		public void AddClient(Client client)
		{
			RestRequest request = new RestRequest("clients/add", Method.POST);
			request.AddJsonBody(client);
			var response = _client.Execute(request);
			var c = response.Content.FromJson<Client>();
			client.ClientId = c.ClientId;
		}

		/// <inheritdoc />
		public void RemoveClient(int clientId)
		{
			RestRequest request = new RestRequest($"clients/{clientId}", Method.DELETE);

			var response = _client.Execute(request);
		}

		/// <inheritdoc />
		public void UpdateClient(Client client)
		{
			RestRequest request = new RestRequest("clients/update", Method.POST);
			request.AddJsonBody(client);
			var response = _client.Execute(request);
		}

		/// <inheritdoc />
		public Client FetchClientById(int clientId)
		{
			RestRequest request = new RestRequest($"clients/{clientId}", Method.GET);
			var response = _client.Execute(request);
			return response.Content.FromJson<Client>();
		}

		/// <inheritdoc />
		public List<Client> FetchClients(ClientSearchParameters searchParameters)
		{
			RestRequest request = new RestRequest("clients/search", Method.POST);
			request.AddJsonBody(searchParameters);
			var response = _client.Execute(request);
			return response.Content.FromJson<List<Client>>();
		}

		/// <inheritdoc />
		public List<Client> FetchAllClients()
		{
			RestRequest request = new RestRequest("clients", Method.GET);

			var response = _client.Execute(request);
			return response.Content.FromJson<List<Client>>();
		}

		#endregion
	}
}
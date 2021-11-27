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
		private readonly IRestClient _client;
		public ApiRepository(IRestClient client)
		{
			_client = client;
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

		/// <inheritdoc />
		public List<PhoneNumber> FetchAllPhoneNumbers()
		{
			RestRequest request = new RestRequest("phones", Method.GET);
			var response = _client.Execute(request);
			return response.Content.FromJson<List<PhoneNumber>>();
		}

		/// <inheritdoc />
		public void AddPhoneNumber(PhoneNumber phoneNumber)
		{
			RestRequest request = new RestRequest("phones/add", Method.POST);
			request.AddJsonBody(phoneNumber);
			var response = _client.Execute(request);

			// I don't like this we are relying on a side effect and is not clear in the signature that something is going to change, we should return a new object imo
			var p = response.Content.FromJson<PhoneNumber>();
			p.PhoneNumberId = p.PhoneNumberId;
		}

		/// <inheritdoc />
		public void RemovePhoneNumber(int phoneId)
		{
			RestRequest request = new RestRequest($"phones/{phoneId}", Method.DELETE);

			var response = _client.Execute(request);
		}

		public void UpdatePhoneNumber(PhoneNumber phone)
		{
			RestRequest request = new RestRequest("phones/update", Method.POST);
			request.AddJsonBody(phone);
			var response = _client.Execute(request);
		}
		#endregion
	}
}
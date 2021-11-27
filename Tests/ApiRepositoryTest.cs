﻿using DependencyInjectionExample.Model;
using DependencyInjectionExample.Repository.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using RestSharp;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Net;

namespace Tests
{
	[TestClass]
	public class ApiRepositoryTest
	{
		public static IRestClient MockRestClient<T>(HttpStatusCode httpStatusCode, string json) where T : new() {

            var data = JsonConvert.DeserializeObject<T>(json);
            var response =  new Mock<IRestResponse<T>>();
            response.Setup(_ => _.StatusCode).Returns(httpStatusCode);
            response.Setup(_ => _.Content).Returns(json);

            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient.Setup(x => x.Execute(It.IsAny<IRestRequest>())).Returns(response.Object);
            return mockIRestClient.Object;
        }

		private Client CreateStandardClient()
		{
			return new Client
			{
				FirstName = Guid.NewGuid().ToString(),
				LastName = Guid.NewGuid().ToString(),
				Addresses = new List<Address>()
				{
					new Address
					{
						City = Guid.NewGuid().ToString(),
						State = Guid.NewGuid().ToString(),
						Country = Guid.NewGuid().ToString(),
						Line1 = Guid.NewGuid().ToString(),
						Line2 = Guid.NewGuid().ToString(),

					}
				},
				PhoneNumbers = new List<PhoneNumber>()
				{
					new PhoneNumber
					{
						Location = "home",
						Number = "88881111"
					}
				}
			};
		}

		[TestMethod]
        public void VerifyCanAddClientTest()
        {
			var client = CreateStandardClient();
			var clonedClient = new Client
			{
				ClientId = 1,
				FirstName = client.FirstName,
				LastName = client.LastName,
				PhoneNumbers = client.PhoneNumbers,
				Addresses = client.Addresses
			};

            var clientAdd = MockRestClient<Client>(HttpStatusCode.OK, clonedClient.ToJson());
			var clientFetch = MockRestClient<Client>(HttpStatusCode.OK, clonedClient.ToJson());
			
			var repository = new ApiRepository(clientAdd);
			Assert.AreEqual(0, client.ClientId);
			repository.AddClient(client);
			Assert.AreNotEqual(0, client.ClientId);
			Assert.IsTrue(client.ClientId > 0);

			repository = new ApiRepository(clientFetch);
			var readBack = repository.FetchClientById(client.ClientId);

            Assert.AreEqual(client.FirstName, readBack.FirstName);
			Assert.AreEqual(client.LastName, readBack.LastName);
			Assert.AreEqual(client.ClientId, readBack.ClientId);
			Assert.AreEqual(client.Addresses[0].Line1, readBack.Addresses[0].Line1);
			Assert.AreEqual(client.Addresses[0].Line2, readBack.Addresses[0].Line2);
			Assert.AreEqual(client.Addresses[0].City, readBack.Addresses[0].City);
			Assert.AreEqual(client.Addresses[0].State, readBack.Addresses[0].State);
			Assert.AreEqual(client.Addresses[0].Country, readBack.Addresses[0].Country);
			Assert.AreEqual(client.Addresses[0].AddressId, readBack.Addresses[0].AddressId);
			Assert.AreEqual(client.Addresses[0].ClientId, readBack.Addresses[0].ClientId);

			Assert.AreEqual(client.PhoneNumbers[0].PhoneNumberId, readBack.PhoneNumbers[0].PhoneNumberId);
			Assert.AreEqual(client.PhoneNumbers[0].ClientId, readBack.PhoneNumbers[0].ClientId);
			Assert.AreEqual(client.PhoneNumbers[0].Location, readBack.PhoneNumbers[0].Location);
			Assert.AreEqual(client.PhoneNumbers[0].Number, readBack.PhoneNumbers[0].Number);
        }
    }
}

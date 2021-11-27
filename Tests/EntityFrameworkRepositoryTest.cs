using API.Data;
using API.Repository;
using DependencyInjectionExample.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
	[TestClass]
	public class EntityFrameworkRepositoryTest
	{
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
			var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
			optionsBuilder.UseSqlite("Data Source=C:\\source\\repos\\interface-examples\\API\\data.db");
			int clientId;

			using (var context = new ApplicationDbContext(optionsBuilder.Options))
			{
				var repository = new EntityFrameworkRepository(context);
				var client = CreateStandardClient();

				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					Assert.AreEqual(0, client.ClientId);
					repository.AddClient(client);

					Assert.AreNotEqual(0, client.ClientId);
					Assert.IsTrue(client.ClientId > 0);

					clientId = client.ClientId;

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

					dbContextTransaction.Rollback();
				}
			}

			using (var context = new ApplicationDbContext(optionsBuilder.Options))
			{
				var repository = new EntityFrameworkRepository(context);
				var outsideScopeReadBack = repository.FetchClientById(clientId);
				Assert.IsNull(outsideScopeReadBack);
			}
		}
	}
}

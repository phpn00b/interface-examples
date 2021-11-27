using DependencyInjectionExample;
using DependencyInjectionExample.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PhonesController : Controller
	{
		private readonly IRepository _repository;
		public PhonesController(IRepository repository)
		{
			_repository = repository;
		}

		#region Implementation of IRepository
		[HttpPost("add")]
		public PhoneNumber AddPhoneNumber(PhoneNumber phone)
		{
			_repository.AddPhoneNumber(phone);
			return phone;
		}

		[HttpGet]
		public List<PhoneNumber> FetchAllPhoneNumbers()
		{
			return _repository.FetchAllPhoneNumbers();
		}

		[HttpGet("remove/{phoneId}")]
		public void RemovePhoneNumber(int phoneId)
		{
			_repository.RemovePhoneNumber(phoneId);
		}

		[HttpPost("update")]
		public void UpdatePhone(PhoneNumber phone)
		{
			_repository.UpdatePhoneNumber(phone);
		}
		#endregion
	}
}

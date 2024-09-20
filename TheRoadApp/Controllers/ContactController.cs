using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheRoadApp.Models.Comment;
using TheRoadApp.Services.Interfaces;

namespace TheRoadApp.Controllers
{
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;
		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}
		public async Task<IActionResult> Index(ContactViewModel contact)
		{
			await _contactService.SendEmailAsync(contact.FullName,contact.Email, contact.Subject, contact.Message);

			return RedirectToAction("Index" , "Home");
		}
	}
}

using System.Threading.Tasks;

namespace TheRoadApp.Services.Interfaces
{
	public interface IContactService
	{
		Task SendEmailAsync(string fullName, string email, string subject, string message);
	}
}

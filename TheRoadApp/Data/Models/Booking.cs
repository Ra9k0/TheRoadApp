using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TheRoadApp.Data.Models
{
	public class Booking
	{
		[ForeignKey(nameof(Tour))]
		public int TourId { get; set; }

		public Tour Tour { get; set; }

		[ForeignKey(nameof(User))]
		public string UserId { get; set; }

		public IdentityUser User { get; set; }
	}
}

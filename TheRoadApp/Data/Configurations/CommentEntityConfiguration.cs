using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheRoadApp.Data.Models;
namespace TheRoadApp.Data.Configurations
{
	public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
	{
		public void Configure(EntityTypeBuilder<Comment> builder)
		{
			builder.HasData(SeedComments());
		}

		private Comment[] SeedComments()
		{
			ICollection<Comment> comments = new HashSet<Comment>();

			Comment comment = new Comment();

			comment = new Comment()
			{
				Id = 1,
				Title = "THESE WERE THE BEST DAYS OF THIS YEAR",
				Content =
					"From cutting down on stress, to lowering your chances of developing a heart disease, the health benefits of traveling are huge. You may stay sitting on a chair all day long at the workplace: including some walking to your trip is sure to make your body feel better.",
				AuthorFullName = "Mirela Stamboliyska",
				Email = "Mirela@gmail.com",
			};
			comments.Add(comment);

			comment = new Comment()
			{
				Id = 2,
				Title = "I ENJOYED THIS GREAT TOUR",
				Content =
					"You might feel like you are stuck in a rut in your daily life. Or you are yearning for something exciting and different. You are craving new experiences and new challenges. Travel is the ideal place to test yourself. Overcoming challenges will bring you joy and energy for future tests. You will realize how capable you are and build your confidence.",
				AuthorFullName = "Ivan Ivanov",
				Email = "Ivan@gmail.com",
			};
			comments.Add(comment);

			return comments.ToArray();
		}
	}
}

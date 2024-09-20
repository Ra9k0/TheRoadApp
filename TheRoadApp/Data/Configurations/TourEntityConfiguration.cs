using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using TheRoadApp.Data.Models;
using TheRoadApp.Data.Models.Enums;

namespace TheRoadApp.Data.Configurations
{
	public class TourEntityConfiguration : IEntityTypeConfiguration<Tour>
	{
		public void Configure(EntityTypeBuilder<Tour> builder)
		{
			builder.HasData(SeedTour());
		}

		private Tour[] SeedTour()
		{
			ICollection<Tour> tours = new HashSet<Tour>();

			Tour tour = new Tour();

			tour = new Tour()
			{
				Id = 1,
				Name = "THE WILD FOREST",
				DurationInDays = 7,
				Capacity = 20,
				TourGuidesCount = 4,
				SleepConditions = "Sleep in private tents",
				Terrain = Difficulty.Medium,
				Price = 399M,
				ImgUrl = "https://i.ibb.co/JkTfQ4Y/forest.jpg",
			};
			tours.Add(tour);

			tour = new Tour()
			{
				Id = 2,
				Name = "ALONG THE RIVER",
				DurationInDays = 9,
				Capacity = 30,
				TourGuidesCount = 7,
				SleepConditions = "Sleep in private tents",
				Terrain = Difficulty.Hard,
				Price = 499M,
				ImgUrl = "https://i.ibb.co/0rBwTyr/river.jpg",
			};
			tours.Add(tour);

			tour = new Tour()
			{
				Id = 3,
				Name = "THE ISLAND BEACH",
				DurationInDays = 5,
				Capacity = 40,
				TourGuidesCount = 8,
				SleepConditions = "Sleep in hotel",
				Terrain = Difficulty.Easy,
				Price = 599M,
				ImgUrl = "https://i.ibb.co/cFfRvPT/sea.jpg",
			};
			tours.Add(tour);

			return tours.ToArray();
		}
	}
}

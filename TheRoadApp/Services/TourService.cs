namespace TheRoadApp.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using TheRoadApp.Data;
    using TheRoadApp.Data.Models;
    using TheRoadApp.Data.Models.Enums;
    using TheRoadApp.Models.Tours;
    using TheRoadApp.Services.Interfaces;

    public class TourService : ITourService
    {
        private readonly ApplicationDbContext _dbContext;

        public TourService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(string name, string imgUrl, int durationInDays, int capacity, int tourGuidesCount, string sleepConditions, Difficulty terrain, decimal price)
        {
            await this._dbContext.Tours.AddAsync(new Tour()
            {
                Name = name,
                ImgUrl = imgUrl,
                DurationInDays = durationInDays,
                Capacity = capacity,
                TourGuidesCount = tourGuidesCount,
                SleepConditions = sleepConditions,
                Terrain = terrain,
                Price = price
            });

            await this._dbContext.SaveChangesAsync();
        }

        public async Task<ToursViewModel> GetAllAsync()
        {
            var tours = new ToursViewModel
            {
                Tours = await this._dbContext.Set<Tour>().OrderByDescending(x => x.Id)
                    .Select(t => new TourViewModel()
                    {
                        Id = t.Id,
                        Name = t.Name,
                        ImgUrl = t.ImgUrl,
                        DurationInDays = t.DurationInDays,
                        Capacity = t.Capacity,
                        Price = t.Price,
                        SleepConditions = t.SleepConditions,
                        Terrain = t.Terrain,
                        TourGuidesCount = t.TourGuidesCount
                    }).Take(3).ToListAsync()
            };

            return tours;
        }

        public async Task<bool> IsBookedAsync(int tourId, string userId)
        {
            return await _dbContext.Booking.AnyAsync(b => b.TourId == tourId && b.UserId == userId);
        }

        public async Task BookAsync(int tourId, string userId)
        {
            Booking booking = new Booking();

            booking.TourId = tourId;
            booking.UserId = userId;

            await _dbContext.AddAsync(booking);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ToursViewModel> BookedTours(string userId)
        {
            var tours = new ToursViewModel
            {
                Tours = await _dbContext.Booking
                .Where(b => b.UserId == userId)
                .Join(_dbContext.Tours,
                      booking => booking.TourId,
                      tour => tour.Id,
                      (booking, tour) => new TourViewModel
                      {
                          Id = tour.Id,
                          Name = tour.Name,
                          ImgUrl = tour.ImgUrl,
                          DurationInDays = tour.DurationInDays,
                          Capacity = tour.Capacity,
                          TourGuidesCount = tour.TourGuidesCount,
                          SleepConditions = tour.SleepConditions,
                          Terrain = tour.Terrain,
                          Price = tour.Price
                      })
                .ToListAsync()
            };

            return tours;
        }
    }
}

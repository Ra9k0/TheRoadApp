namespace TheRoadApp.Services.Interfaces
{
    using System.Threading.Tasks;

    using TheRoadApp.Data.Models.Enums;
    using TheRoadApp.Models.Tours;

    public interface ITourService
    {
        Task AddAsync(string name,
            string imgUrl, int durationInDays, int capacity, int tourGuidesCount,
            string sleepConditions, Difficulty terrain, decimal price);

        Task<ToursViewModel> GetAllAsync();

        Task<bool> IsBookedAsync(int tourId, string userId);

        Task BookAsync(int tourId, string userId);

        Task<ToursViewModel> BookedTours(string userId);
    }
}

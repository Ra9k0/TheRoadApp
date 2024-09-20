namespace TheRoadApp.Components
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using TheRoadApp.Services.Interfaces;

    public class AllToursComponent : ViewComponent
    {
        private readonly ITourService tourService;

        public AllToursComponent(ITourService tourService)
        {
            this.tourService = tourService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await this.tourService.GetAllAsync();

            return this.View(model);
        }
    }
}

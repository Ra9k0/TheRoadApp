using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace TheRoadApp.Controllers
{
	using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using TheRoadApp.Models.Tours;
    using TheRoadApp.Services.Interfaces;


    [Authorize]
    public class TourController : Controller
    {
        private readonly ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost(AddTourInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this._tourService.AddAsync(inputModel.Name, inputModel.ImgUrl, inputModel.DurationInDays, inputModel.Capacity,
                inputModel.TourGuidesCount, inputModel.SleepConditions, inputModel.Terrain, inputModel.Price);
            
            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Book(int id)
        {
	        await _tourService.BookAsync(id,User.FindFirstValue(ClaimTypes.NameIdentifier));

	        return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Booked()
        {
            var tours = await _tourService.BookedTours(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View(tours);
        }

    }
}

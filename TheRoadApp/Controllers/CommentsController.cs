namespace TheRoadApp.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using TheRoadApp.Models.Comment;
    using TheRoadApp.Services.Interfaces;

    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCommentInputModel inputModel)
        {
            await this._commentService.AddAsync(inputModel.AuthorFullName, inputModel.Email, inputModel.Title,
                inputModel.Content);

            return this.RedirectToAction("Index", "Home");
        }
    }
}

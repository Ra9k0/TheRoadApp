namespace TheRoadApp.Components
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using TheRoadApp.Services.Interfaces;
    
    public class AllCommentsComponent : ViewComponent
    {
        private readonly ICommentService commentsService;

        public AllCommentsComponent(ICommentService commentsService)
        {
            this.commentsService = commentsService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await this.commentsService.GetAllAsync();

            return this.View(model);
        }
    }
}

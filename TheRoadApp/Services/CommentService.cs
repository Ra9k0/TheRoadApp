namespace TheRoadApp.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using TheRoadApp.Models.Comment;
    using TheRoadApp.Data;
    using TheRoadApp.Data.Models;
    using TheRoadApp.Services.Interfaces;

    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;

        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(string authorFullName, string email, string title, string content)
        {
            await this._context.Comments.AddAsync(new Comment()
            {
                AuthorFullName = authorFullName,
                Email = email,
                Title = title,
                Content = content
            });

            await this._context.SaveChangesAsync();
        }

        public async Task<CommentsViewModel> GetAllAsync()
        {
            var comments = new CommentsViewModel();

            comments.Comments = await this._context
                .Set<Comment>()
                .Select(c => new CommentViewModel()
                {
                    AuthorFullName = c.AuthorFullName,
                    Email = c.Email,
                    Title = c.Title,
                    Content = c.Content
                }).ToListAsync();

            return comments;
        }
    }
}

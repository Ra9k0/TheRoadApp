namespace TheRoadApp.Services.Interfaces
{
    using System.Threading.Tasks;

    using TheRoadApp.Models.Comment;

    public interface ICommentService
    {
        Task AddAsync(string authorFullName, string email, string title, string content);

        Task<CommentsViewModel> GetAllAsync();
    }
}

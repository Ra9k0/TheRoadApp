namespace TheRoadApp.Models.Comment
{
    public class AddCommentInputModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorFullName { get; set; }

        public string Email { get; set; }
    }
}

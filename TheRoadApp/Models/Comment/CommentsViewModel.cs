namespace TheRoadApp.Models.Comment
{
    using System.Collections.Generic;

    public class CommentsViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}

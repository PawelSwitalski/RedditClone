namespace RedditClone.ViewModels
{
    public class PostViewModel
    {
        public string Id { get; set; }
        // User nick that create post could be null
        public string UserName { get; set; }
        public string Title { get; set; }
        public string BodyText { get; set; }
        public int LikesNumber { get; set; }

    }
}

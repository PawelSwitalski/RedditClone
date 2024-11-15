namespace RedditClone.ViewModels
{
    public class HomePageViewModel
    {
        public UserPublicDataViewModel UserData { get; set; }
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}

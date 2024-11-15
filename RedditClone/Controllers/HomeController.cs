using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedditClone.Services;
using RedditClone.ViewModels;
using System.Collections;
using System.Diagnostics;

namespace RedditClone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPostRepository _postRepository;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, IPostRepository postRepository)
        {
            _logger = logger;
            _userManager = userManager;
            _postRepository = postRepository;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _postRepository.GetAllWithUserAsync();
            var postViewModels = new LinkedList<PostViewModel>();

            foreach (var post in posts)
            {
                postViewModels.AddLast(
                    new PostViewModel
                    {
                        Id = post.Id.ToString(),
                        UserName = post.User?.UserName ?? "Anonymous",
                        Title = post.Title,
                        BodyText = post.BodyText,
                        LikesNumber = post.LikesNumber,

                    });
            }

            var homeViewModel = new HomePageViewModel();
            homeViewModel.Posts = postViewModels;




            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

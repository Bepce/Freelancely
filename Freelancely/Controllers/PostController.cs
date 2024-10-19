using Freelancely.Core.Contracts.Post;
using Microsoft.AspNetCore.Mvc;

namespace Freelancely.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostService postService;

        public PostController(
            ILogger<PostController> logger,
            IPostService _postService)
        {
            _logger = logger;
            postService = _postService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await postService.LastThreePosts();

            return View(model);
        }
    }
}

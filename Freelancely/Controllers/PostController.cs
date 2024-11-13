using Freelancely.Core.Contracts.Post;
using Freelancely.Core.Models.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


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

        [HttpGet]        
        public async Task<IActionResult> Details(int id)
        {
            var model = await postService.PostById(id);

            if (model == null) 
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]  
        public async Task<IActionResult> Create([FromForm]PostFormModel createFormModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createFormModel);
            }

            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null) 
            {
                return Unauthorized();
            }

            var newPostId = await postService.CreatePostAsync(createFormModel, userId);

            return RedirectToAction(nameof(Details), new {id = newPostId});
        }
    }
}

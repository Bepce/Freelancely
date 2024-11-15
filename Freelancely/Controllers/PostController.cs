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
            var model = await postService.LastNinePosts();

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
        public async Task<IActionResult> Create([FromForm] PostFormModel createFormModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createFormModel);
            }

            string? userId = User.Id();

            if (userId == null)
            {
                return Unauthorized();
            }

            var newPostId = await postService.CreatePostAsync(createFormModel, userId);

            return RedirectToAction(nameof(Details), new { id = newPostId });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            string? userId = User.Id();

            var post = await postService.PostById(id);

            if (post == null)
            {
                return NotFound();
            }

            if (userId != post.postUserId)
            {
                return Unauthorized();
            }

            var postEditForm = new PostFormModel
            {
                Title = post.PostTitle,
                Description = post.PostBody,
                Price = post.Price
            };

            return View(postEditForm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostFormModel model, int id)
        {
            var post = await postService.PostById(id);

            if (post == null)
            {
                return BadRequest();
            }

            if (post.postUserId != User.Id())
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            await postService.UpdatePost(model, id);

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}

using Freelancely.Core.Contracts.Post;
using Freelancely.Core.Contracts.WorkIndustry;
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
        private readonly IPostService _postService;
        private readonly IWorkIdustryService _workIdustryService;

        public PostController(
            ILogger<PostController> logger,
            IPostService postService,
            IWorkIdustryService workIdustryService)
        {
            _logger = logger;
            _postService = postService;
            _workIdustryService = workIdustryService;
            
        }


        public async Task<IActionResult> Index()
        {
            var model = await _postService.GetPostsAsync(9);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _postService.PostById(id);

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View(new PostFormModel
            {
                WorkIndustries = await _workIdustryService.GetWorkIndustries()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PostFormModel createFormModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createFormModel);
            }

            string? userId = User.GetId();

            if (userId == null)
            {
                return Unauthorized();
            }

            var newPostId = await _postService.CreatePostAsync(createFormModel, userId);

            return RedirectToAction(nameof(Details), new { id = newPostId });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            string? userId = User.GetId();

            var post = await _postService.PostById(id);

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
                Price = post.Price,
                WorkIndustries = await _workIdustryService.GetWorkIndustries()
            };

            return View(postEditForm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostFormModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var post = await _postService.PostById(id);

            if (post == null)
            {
                return BadRequest();
            }

            if (post.postUserId != User.GetId())
            {
                return Unauthorized();
            }            
            
            await _postService.UpdatePostAsync(model, id);

            return RedirectToAction(nameof(Details), new { id });
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _postService.PostById(id);

            if (post == null)
            {
                return BadRequest();
            }

            if (post.postUserId != User.GetId())
            {
                return Unauthorized();
            }

            await _postService.DeletePostAsync(id);

            TempData["Delete message"] = "The post has been deleted.";

            return RedirectToAction(nameof(Index));
        }
    }
}

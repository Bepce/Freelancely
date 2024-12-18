using Freelancely.Core.Contracts.WorkIndustry;
using Freelancely.Core.Models.WorkIndustry;
using static Freelancely.Core.Constants.MessageConstants;
using static Freelancely.Web.Areas.Admin.AdminConstants;
using Microsoft.AspNetCore.Mvc;




namespace Freelancely.Web.Areas.Admin.Controllers
{
    public class WorkIndustryController : AdminController
    {
        private readonly ILogger<WorkIndustryController> _logger;
        private readonly IWorkIdustryService _workIndustryService;

        public WorkIndustryController(
            ILogger<WorkIndustryController> logger,
            IWorkIdustryService workIdustryService)
        {
            _logger = logger;
            _workIndustryService = workIdustryService;             
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm]WorkIndustryFormModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            if (await _workIndustryService.WorkIndustryExists(model.Name))
            {
                ModelState.AddModelError("", WorkIndustryAlreadyExists);
                return View(model);
            }


            await _workIndustryService.CreateWorkIndustryAsync(model);

            return RedirectToAction(nameof(Index));
        }
    }
}

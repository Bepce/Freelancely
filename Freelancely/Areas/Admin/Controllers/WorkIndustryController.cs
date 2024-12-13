using Microsoft.AspNetCore.Mvc;

namespace Freelancely.Web.Areas.Admin.Controllers
{
    public class WorkIndustryController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

    }
}

using Microsoft.AspNetCore.Mvc;

namespace Freelancely.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Index() => View();
        
    }
}

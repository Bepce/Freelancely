using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Freelancely.Web.Areas.Admin.AdminConstants;

namespace Freelancely.Web.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class AdminController : Controller
    {
    }
}

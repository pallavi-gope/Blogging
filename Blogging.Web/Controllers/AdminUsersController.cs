using Microsoft.AspNetCore.Mvc;

namespace Blogging.Web.Controllers
{
    public class AdminUsersController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}

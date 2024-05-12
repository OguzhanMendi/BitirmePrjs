using Microsoft.AspNetCore.Mvc;

namespace BitirmePrjs.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

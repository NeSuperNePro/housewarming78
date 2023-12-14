using housewarming78.Domain;
using housewarming78.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace housewarming78.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }     
    }
}

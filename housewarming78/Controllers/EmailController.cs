using housewarming78.Domain;
using housewarming78.Service;
using Microsoft.AspNetCore.Mvc;

namespace housewarming78.Controllers
{
    public class EmailController : Controller
    {
        private readonly Email email;

        public EmailController(Email email) 
        {
            this.email = email;
        }

        [HttpPost]
        public IActionResult SendEmail(string validationName, string validationPhone)
        {
            Console.WriteLine(validationName);
            Console.WriteLine(validationPhone);
            email.SendEmail(validationName, validationPhone);

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}

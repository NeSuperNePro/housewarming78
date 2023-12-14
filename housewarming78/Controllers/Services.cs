using housewarming78.Domain;
using Microsoft.AspNetCore.Mvc;

namespace housewarming78.Controllers
{
    public class Services : Controller
    {
        private readonly DataManager dataManager;

        public Services(DataManager dataManager) 
        { 
            this.dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.RealEstates.GetRealEstateById(id));
            }
            //ViewBag.RealEstate = dataManager.RealEstates.
            return View(dataManager.RealEstates.GetRealEstate());
        }
    }
}

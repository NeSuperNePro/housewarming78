using housewarming78.Domain;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


namespace housewarming78.Controllers
{
    public class SerchController : Controller
    {
        private readonly DataManager dataManager;

        public SerchController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Serch(string? addr, double? priceTo, double? priceDo, bool rooms1, bool rooms2, bool rooms3, bool rooms4, bool rooms5, bool rooms6, bool room, bool studio, bool newBuilding, bool oldBuilding)
        {
            var select = from entity in dataManager.RealEstates.GetRealEstate() select entity;
            
            if (select.Any())
            {
                if (addr != null) select = select.Where(x => x.Address == addr);
                if (priceTo != null) select = select.Where(x => x.Price >= priceTo);
                if (priceDo != null) select = select.Where(x => x.Price <= priceDo);
                if (newBuilding || oldBuilding) 
                    select = select.Where(x => 
                    (newBuilding & x.HousingType.Contains("Новостройка")) || 
                    (oldBuilding & x.HousingType.Contains("Вторичка")) 
                    );
                if (rooms1 || rooms2 || rooms3 || rooms4 || rooms5 || room || studio)
                    select = select.Where(x => 
                    (rooms1 & x.CountRooms.Contains("1")) || 
                    (rooms2 & x.CountRooms.Contains("2")) || 
                    (rooms3 & x.CountRooms.Contains("3")) || 
                    (rooms4 & x.CountRooms.Contains("4")) || 
                    (rooms5 & x.CountRooms.Contains("5")) ||
                    (room & x.CountRooms.Contains("Комната")) || 
                    (studio & x.CountRooms.Contains("Студия"))
                    );
                if (rooms6)
                {
                    int rooms;
                    select = select.Where(x => Convert.ToInt32(x.CountRooms) >= 6);
                }

                return ViewComponent("Serch", select);
            }
            return ViewComponent("Serch", dataManager.RealEstates.GetRealEstate());
        }
    }
}

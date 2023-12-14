using housewarming78.Domain;
using housewarming78.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace housewarming78.Model.ViewComponents
{
    public class SerchViewComponent : ViewComponent
    {
        private readonly DataManager dataManager;

        public SerchViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public Task<IViewComponentResult> InvokeAsync(IQueryable<RealEstate> select)
        {
            return Task.FromResult((IViewComponentResult)View( select == null ? dataManager.RealEstates.GetRealEstate() : select));
        }
    }
}
        
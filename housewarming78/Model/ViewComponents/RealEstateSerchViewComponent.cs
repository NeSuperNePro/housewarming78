using housewarming78.Domain.Entities;
using housewarming78.Domain;
using Microsoft.AspNetCore.Mvc;

namespace housewarming78.Model.ViewComponents
{
    public class RealEstateSerchViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(IQueryable<RealEstate> select)
        {
            return Task.FromResult((IViewComponentResult)View());
        }
    }
}

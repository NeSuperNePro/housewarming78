using housewarming78.Domain;
using Microsoft.AspNetCore.Mvc;

namespace housewarming78.Model.ViewComponents
{
    public class EmailViewComponent : ViewComponent
    {
        private readonly Email email;

        public EmailViewComponent(Email email)
        {
            this.email = email;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View());
        }
        
    }
}

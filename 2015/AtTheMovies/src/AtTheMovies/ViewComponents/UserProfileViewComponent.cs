using AtTheMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtTheMovies.ViewComponents
{
    public class UserProfileViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = new MovieUser {Name = "Scott", Score = -10};
            return View(model);
        }
    }
}

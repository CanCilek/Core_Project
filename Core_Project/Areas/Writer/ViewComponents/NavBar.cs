using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Project.Areas.Writer.ViewComponents
{
    public class NavBar : ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public NavBar(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value =await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = value.ImageUrl;
            return View();
        }
    }
}

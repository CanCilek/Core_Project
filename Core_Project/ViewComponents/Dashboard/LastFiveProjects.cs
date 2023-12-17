using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Project.ViewComponents.Dashboard
{
    public class LastFiveProjects : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {         
            return View();
        }
    }
}

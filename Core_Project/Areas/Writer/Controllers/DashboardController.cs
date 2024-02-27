using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        

        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;

            //Weather API

            string api = "5d2345e9f33a20a465024d211f31b3bc";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&units=metric&lang=tr&mode=xml&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            //Statistic

            Context c = new Context();

            ViewBag.v1 = 0;
            ViewBag.v2 = c.Announcements.Count();
            ViewBag.v3 = 0;
            ViewBag.v4 = c.Skills.Count();

            return View();
        }
    }
}
/*

 https://api.openweathermap.org/data/2.5/weather?q=istanbul&appid=5d2345e9f33a20a465024d211f31b3bc&units=metric&lang=tr&mode=xml

 */
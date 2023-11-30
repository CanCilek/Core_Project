using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Project.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Proje Listesi";
            ViewBag.v2 = "Proje";
            ViewBag.v3 = "Proje Listesi";
            var values = portfolioManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProject()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddProject(Portfolio p)
        {
            ViewBag.v1 = "Proje Ekleme";
            ViewBag.v2 = "Proje";
            ViewBag.v3 = "Proje Ekleme";
            portfolioManager.TAdd(p);
            return RedirectToAction("Index");
        }
    }
}

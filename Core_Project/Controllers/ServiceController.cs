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
    public class ServiceController : Controller
    {

        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());

        public IActionResult Index()
        {
            ViewBag.v1 = "Hizmetlerim";
            ViewBag.v2 = "Hizmetlerim";
            ViewBag.v3 = "Hizmetlerim Sayfası";
            var values = serviceManager.TGetList();
            return View(values);
        }

        public IActionResult DeleteService(int id)
        {
            var value = serviceManager.TGetByID(id);
            serviceManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddService()
        {
            ViewBag.v1 = "Hizmetlerim";
            ViewBag.v2 = "Hizmetlerim";
            ViewBag.v3 = "Hizmet Ekleme Sayfası";
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service s)
        {
            serviceManager.TAdd(s);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            ViewBag.v1 = "Hizmet Güncelle";
            ViewBag.v2 = "Hizmetlerim";
            ViewBag.v3 = "Hizmet Güncelle";
            var value = serviceManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateService(Service s)
        {
            serviceManager.TUpdate(s);
            return RedirectToAction("Index");
        }
    }
}

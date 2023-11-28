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
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Yetenekler Listesi";
            ViewBag.v2 = "Skill";
            ViewBag.v3 = "Yetenekler Listesi";
            var values = skillManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.v1 = "Yetenekler";
            ViewBag.v2 = "Skill";
            ViewBag.v3 = "Yetenekler";
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill p)
        {
            skillManager.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSkill(int id)
        {
            var value = skillManager.TGetByID(id);
            skillManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewBag.v1 = "Yetenek Güncelle";
            ViewBag.v2 = "Skill";
            ViewBag.v3 = "Yetenek Güncelle";
            var values = skillManager.TGetByID(id);
            return View(values);

        }

        [HttpPost]
        public IActionResult EditSkill(Skill p)
        {
            skillManager.TUpdate(p);
            
            return RedirectToAction("Index");

        }
    }
}

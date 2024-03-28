using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Project.Controllers
{
    public class ContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            var values = messageManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteContact(int id)
        {
            var value = messageManager.TGetByID(id);
            messageManager.TDelete(value);
            return RedirectToAction("Index");
        }
        public IActionResult ContactDetails(int id)
        {
            var value = messageManager.TGetByID(id);
            return View(value);
        }
    }
}

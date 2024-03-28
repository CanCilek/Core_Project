using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Project.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult ReceiverMessageList()
        {
            string p;
            p = "deneme@gmail.com";
            var values = writerMessageManager.GetListReceiverMessage(p);

            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string p;
            p = "deneme@gmail.com";
            var values = writerMessageManager.GetListSenderMessage(p);

            return View(values);
        }
        public IActionResult AdminMessageDetails(int id)
        {
            var value = writerMessageManager.TGetByID(id);
            return View(value);
        }
        public IActionResult AdminMessageDelete(int id)
        {
            string p;
            p = "deneme@gmail.com";
            var value = writerMessageManager.TGetByID(id);

            if(value.Receiver == p)
            {
                writerMessageManager.TDelete(value);
                return RedirectToAction("ReceiverMessageList");
            }
            else
            {
                writerMessageManager.TDelete(value);
                return RedirectToAction("SenderMessageList");
            }
            
        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage p)
        {
            p.Sender = "deneme@gmail.com";
            p.SenderName = "Eyüp Sarıcı";
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            writerMessageManager.TAdd(p);

            return RedirectToAction("SenderMessageList");
        }
    }
}

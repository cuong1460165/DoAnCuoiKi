using LTWeb_05.Helpers;
using LTWeb_05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb_05.Controllers
{
    public class ManageController : Controller
    {
        //
        // GET: /Manage/
        public ActionResult ListUser()
        {
            using (var ctx = new QLBHEntities())
            {
                var list = ctx.Users.ToList();
                return View(list);
            }
        }
        
        public ActionResult DeleteUser(int? id)
        {
            if (id.HasValue == false)
            {
                return RedirectToAction("ListUser", "Manage");
            }
            ViewBag.f_ID = id;
            return View();
        }

        [HttpPost]
        public ActionResult DeleteUser(int idToDelete)
        {
            using (var ctx = new QLBHEntities())
            {
                User model = ctx.Users
                    .Where(p => p.f_ID == idToDelete)
                    .FirstOrDefault();
                ctx.Users.Remove(model);
                ctx.SaveChanges();
            }
            return RedirectToAction("ListUser", "Manage");
        }
       
        [HttpPost]
        public ActionResult ResetPass(User us)
        {
            using (var ctx = new QLBHEntities())
            {
                var list = ctx.Users.ToList();
                User userToRS = list.Where(u => u.f_ID == us.f_ID)
                    .FirstOrDefault<User>();
                userToRS.f_Password = StringUtils.Md5(us.f_Email);
                ctx.SaveChanges();
                return RedirectToAction("ListUser", "Manage");
            }
        }
	}
}
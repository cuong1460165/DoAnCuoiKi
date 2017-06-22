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
        public ActionResult ListCat()
        {
            using (var ctx = new QLBHEntities())
            {
                var list = ctx.Categories.ToList();
                return View(list);
            }
        }
        public ActionResult AddCat()
        {
            return View();
        }
        //
        // POST: /Product/Add
        [HttpPost]
        public ActionResult AddCat(Category model)
        {
            using (var ctx = new QLBHEntities())
            {
                ctx.Categories.Add(model);
                ctx.SaveChanges();
            }
            return View();
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
        public ActionResult DeleteCat(int? id)
        {
            if (id.HasValue == false)
            {
                return RedirectToAction("ListCat", "Manage");
            }
            ViewBag.CatID = id;
            return View();
        }

        [HttpPost]
        public ActionResult DeleteCat(int idToDelete)
        {
            using (var ctx = new QLBHEntities())
            {
                Category model = ctx.Categories
                    .Where(p => p.CatID == idToDelete)
                    .FirstOrDefault();
                ctx.Categories.Remove(model);
                ctx.SaveChanges();
            }
            return RedirectToAction("ListCat", "Manage");
        }
         public ActionResult EditCat(int? id)
        {
            if (id.HasValue == false)
            {
                return RedirectToAction("ListCat", "Manage");
            }
            using (var ctx = new QLBHEntities())
            {
                Category model = ctx.Categories
                    .Where(p => p.CatID == id)
                    .FirstOrDefault();
                return View(model);
            }
        }
        //
        // GET: /Product/Update
        [HttpPost]
        public ActionResult Update(Category model)
        {
            using (var ctx = new QLBHEntities())
            {
                ctx.Entry(model).State = 
                    System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("ListCat", "Manage");
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
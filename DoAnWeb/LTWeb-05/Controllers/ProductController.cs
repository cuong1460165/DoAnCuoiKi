using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb_05.Models;
namespace LTWeb_05.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Product(int page = 1)
        {
           using (var ctx = new QLBHEntities())
           {
               int n = ctx.Products.Count();
               int recordsPerPage = 6;
               int nPages = n / recordsPerPage;
               int m = n % recordsPerPage;
               if (m > 0)
               {
                   nPages++;
               }
               ViewBag.Pages = nPages;
               ViewBag.CurPage = page;
               var list = ctx.Products
                   .OrderBy(p => p.ProID)
                   .Skip((page - 1) * recordsPerPage)
                   .Take(recordsPerPage)
                   .ToList();

               //var list = ctx.Products
               //    .Where(p => id == p.CatID)
               //    .ToList();
               return View(list);
           }
        }
        //
        // GET: /Product/ByCat
        public ActionResult ByCat(int ?id, int page = 1)
        {
            if(id.HasValue == false)
            {
                return RedirectToAction("Index", "Home");
            }
            using (var ctx = new QLBHEntities())
            {
                int n = ctx.Products
                    .Where(p => p.CatID == id)
                    .Count();
                int recordsPerPage = 6;
                int nPages = n / recordsPerPage;
                int m = n % recordsPerPage;
                if(m > 0)
                {
                    nPages++;
                }
                ViewBag.Pages = nPages;
                ViewBag.CurPage = page;
                var list = ctx.Products
                    .Where(p => p.CatID == id)
                    .OrderBy(p => p.ProID)
                    .Skip((page-1)*recordsPerPage)
                    .Take(recordsPerPage)
                    .ToList();

                //var list = ctx.Products
                //    .Where(p => id == p.CatID)
                //    .ToList();
                return View(list);
            }
        }

        public ActionResult Detail(int? id)
        {
            if (id.HasValue == false)
            {
                return RedirectToAction("Index", "Home");
            }
            using (var ctx = new QLBHEntities())
            {
                var model = ctx.Products
                    .Where(p => p.ProID == id)
                    .FirstOrDefault();
                return View(model);
            }
        }
      
    }
}
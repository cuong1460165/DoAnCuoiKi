using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb_05.Models;
using LTWeb_05.Filter;
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
        //
        // GET: /Product/Detail
        [CheckLogin]
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
        [HttpPost]
        public ActionResult Detail(BidDetail model,int id)
        {
            BidDetail bid = new BidDetail();
            using (var ctx = new QLBHEntities())
            {
                bid.BidPrice = ctx.BidDetails.Where(p => p.ProID == model.ProID).Max(p => p.BidPrice);
            }
            using (var ctx = new QLBHEntities())
            {
                ctx.BidDetails.Add(model);
                ctx.SaveChanges();
            }
            return RedirectToAction("EditMaxPrice", "Product", new { proid = model.ProID, bidprice = model.BidPrice, bidpricemaxbefore = bid.BidPrice});
        }
      
        public ActionResult EditMaxPrice(double bidprice,int? proid, double bidpricemaxbefore)
        {
            if (proid.HasValue == false)
            {
                return RedirectToAction("Index", "Home");
            }
            Product model = new Product();
            using (var ctx = new QLBHEntities())
            {
                     model = ctx.Products
                    .Where(p => p.ProID == proid)
                    .FirstOrDefault();
            }
            ViewBag.BidPriceMaxBefore = bidpricemaxbefore;
            ViewBag.BidPrice = bidprice;
            //BidDetail bid = new BidDetail();
            //using (var ctx = new QLBHEntities())
            //{
            //    bid.BidPrice = ctx.BidDetails.Where(p => p.ProID == proid).Max(p => p.BidPrice);
            //}
            //ViewBag.BidPriceMax = bid.BidPrice;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateMaxPrice(Product model)
        {
            BidDetail c = new BidDetail();
            using (var ctx = new QLBHEntities())
            {
                ctx.Entry(model).State =
                    System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("Detail", "Product", new { id = model.ProID });
        }
    }
}
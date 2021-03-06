﻿using LTWeb_05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb_05.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index(int page = 1)
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
	}
}
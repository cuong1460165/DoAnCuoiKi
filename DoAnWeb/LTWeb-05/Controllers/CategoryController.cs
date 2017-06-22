﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb_05.Models;
namespace LTWeb_05.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        public ActionResult List()
        {

            using (var ctx = new QLBHEntities())
            {
                var list = ctx.Categories.ToList();
                return PartialView("ListPartial",list);
            }
          

        }
	}
}
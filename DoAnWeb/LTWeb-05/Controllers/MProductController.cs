using LTWeb_05.Filter;
using LTWeb_05.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb_05.Controllers
{
     [CheckLogin(RequiredPermission = 1)]
    public class MProductController : Controller
    {
        //
        // GET: /MProduct/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
           using (var ctx = new QLBHEntities())
           {
               var list = ctx.Categories.ToList();
               ViewBag.Categories = list;
           }
            return View();
        }
         [HttpPost]
         [ValidateInput(false)]
        public ActionResult Add(Product vm, HttpPostedFileBase fuMain, HttpPostedFileBase fuThumbs1, HttpPostedFileBase fuThumbs2)
        {
            if (vm.FullDes == null) vm.FullDes = string.Empty;
            if (vm.TinyDes == null) vm.TinyDes = string.Empty;
             using(var ctx = new QLBHEntities())
             {
                 ctx.Products.Add(vm);
                 ctx.SaveChanges();

                 if(fuMain != null && fuMain.ContentLength > 0 && fuThumbs1 != null && fuThumbs1.ContentLength > 0 && fuThumbs2 != null && fuThumbs2.ContentLength >0)
                 {
                     string sDirPath = Server.MapPath("~/Imgs/sp");
                     string targetDirPath = Path.Combine(sDirPath, vm.ProID.ToString());
                     Directory.CreateDirectory(targetDirPath);
                     string mainFileName = Path.Combine(targetDirPath, "main_thumbs.jpg");
                     fuMain.SaveAs(mainFileName);
                     string thumbs1FileName = Path.Combine(targetDirPath, "main_thumbs1.jpg");
                     fuThumbs1.SaveAs(thumbs1FileName);
                     string thumbs2FileName = Path.Combine(targetDirPath, "main_thumbs2.jpg");
                     fuThumbs2.SaveAs(thumbs2FileName);
                 }

                 var list = ctx.Categories.ToList();
                 ViewBag.Categories = list;
             }
             
             return View();
        }
	}
}
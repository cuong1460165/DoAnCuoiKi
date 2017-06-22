using LTWeb_05.Helpers;
using LTWeb_05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb_05.Controllers
{
    public class ViewInfoController : Controller
    {
        //
        // GET: /ViewInfo/
        public ActionResult WatchList()
        {
            using (var ctx = new QLBHEntities())
            {
                var iduser = CurrentContext.GetCurUser().f_ID;
                var list = (from p in ctx.Products
                            join f in ctx.FavoriteProducts
                            on p.ProID equals f.ProID
                            where f.f_IDLike == iduser
                            select new ProductVM
                            {
                                ProID = p.ProID,
                                ProName = p.ProName,
                                TinyDes = p.TinyDes,
                                FullDes = p.FullDes,
                                Price = p.Price,
                                CatID = p.CatID,
                                MaxPrice = p.MaxPrice,
                                Expried = p.Expried,
                            }).ToList();
                return View(list);
            }
        }
	}
}
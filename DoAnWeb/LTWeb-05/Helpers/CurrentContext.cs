using System.Web;
using LTWeb_05.Models;
using System;
using System.Linq;
namespace LTWeb_05.Helpers
{
    public class CurrentContext
    {
        public static bool IsLogged()
        {
            var flag = HttpContext.Current.Session["isLogin"];
            if(flag == null || (int)flag == 0){
                if(HttpContext.Current.Request.Cookies["userId"] != null)
                {
                    int userIdCookie = Convert.ToInt32(HttpContext.Current.Request.Cookies["userId"].Value);
                    using (var ctx = new QLBHEntities())
                    {
                        var user = ctx.Users
                            .Where(u => u.f_ID == userIdCookie)
                            .FirstOrDefault();
                        HttpContext.Current.Session["isLogin"] = 1;
                        HttpContext.Current.Session["user"] = user;
                    };
                    return true;
                }
                return false;
            }
            return true;
        }
        public static User GetCurUser(){
            return (User)HttpContext.Current.Session["user"];
        }
        public static void Destroy()
        {
            HttpContext.Current.Session["isLogin"] = 0;
            HttpContext.Current.Session["user"] = null;
            HttpContext.Current.Response.Cookies["userId"].Expires = DateTime.Now.AddDays(-1);
        }
    }
}
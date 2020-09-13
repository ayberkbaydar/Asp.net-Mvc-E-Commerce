using Mvc.Eticaret.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Mvc.Eticaret.UI.Web.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Admin/AdminLogin
        MvcDB db = new MvcDB();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Email,string Password)
        {
            var data=db.Users.Where(x => x.Email == Email && x.Password == Password && x.IsActive==true && x.IsAdmin==true).ToList();
            if (data.Count==1)
            {
                //başarılı giriş
                Session["AdminLoginUser"] = data.FirstOrDefault();
                return Redirect("/admin");
            }
            else
            {
                //başarısız
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session["AdminLoginUser"] = null;
            Session.Abandon();
            return View();
        }
    }
}
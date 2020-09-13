using Mvc.Eticaret.Core.Model;
using Mvc.Eticaret.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Eticaret.UI.Web.Controllers
{
    public class HomeController : MvcControllerBase
    {
        MvcDB db = new MvcDB();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.IsLogin = this.IsLogin;
            var data = db.Products.OrderByDescending(x => x.ID).Take(15).ToList();//desc ile ürünleri idlerine göre tersten sıraladık take ile 15 tanesini aldık(son eklenen 15 ürün).
            return View(data);
        }
        public PartialViewResult GetMenu()//menü datasını dbden çekeceğiz.
        {
            var menus = db.Categories.Where(x => x.ParentID == 0).ToList();//parentid 0 olanlar ana menülerim
            return PartialView(menus);
        }
        [Route("Uye-Giris")] //ismini uye-giris olarak route ettik app_start routeconfige mapmvcattributeroute ayarını unutma
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("Uye-Giris")] //ismini uye-giris olarak route ettik app_start routeconfige mapmvcattributeroute ayarını unutma
        public ActionResult Login(string Email,string Password)//otomap için parametre isimlerinin textboxlara verdiğmz idlerle aynı yapalım.
        {
            var users = db.Users.Where(x => x.Email == Email && x.Password==Password && x.IsActive==true && x.IsAdmin==false).ToList();
            if (users.Count==1)
            {
                //giriş yapıldı.
                Session["LoginUserID"] = users.FirstOrDefault().ID; ;
                Session["LoginUser"] = users.FirstOrDefault();
                return Redirect("/"); //anasayfa
            }
            else
            {
                ViewBag.Error = "Hatalı Email Veya Şifre!!!"; //login.cshtml pagede kullanmak için yazdık.
                return View();
            }
        }

        [Route("Uye-Kayit")]
        public ActionResult CreateUser()//üye kayıt 
        {
            return View();
        }

        [HttpPost]
        [Route("Uye-Kayit")]
        public ActionResult CreateUser(User entity)
        {
            //burada verdiğim alanları createuser.cshtml pageinden sildiğim için burada veriyorum.
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.CreateUserID = 1;
                entity.IsActive = true;
                entity.IsAdmin = false;

                db.Users.Add(entity);
                db.SaveChanges();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session["LoginUser"] = null;
            Session.Abandon();
            return View();
        }
    }
}
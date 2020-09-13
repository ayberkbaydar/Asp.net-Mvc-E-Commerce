using Mvc.Eticaret.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Eticaret.UI.Web.Controllers
{
    public class CategoryController : MvcControllerBase
    {
        // GET: Category
        [Route("Kategori/{isim}/{id}")]
        public ActionResult Index(string isim,int id)
        {
            ViewBag.IsLogin = this.IsLogin;
            var db = new MvcDB();
            var data = db.Products.Where(x => x.IsActive == 1 && x.CategoryID == id).OrderByDescending(x=>x.ID).ToList();//db category tabledaki isactive alanı bool çevirince buradaki isactive i true ile değiştir.
            ViewBag.category = db.Categories.Where(x => x.ID == id).FirstOrDefault();
            return View(data);
        }
    }
}
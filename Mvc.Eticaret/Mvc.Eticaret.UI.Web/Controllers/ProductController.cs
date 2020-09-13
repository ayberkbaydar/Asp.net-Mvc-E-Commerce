using Mvc.Eticaret.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Eticaret.UI.Web.Controllers
{
    public class ProductController : MvcControllerBase
    {
        // GET: Product
        [Route("Urun/{title}/{id}")]
        public ActionResult Detail(string title,int id)
        {
            ViewBag.IsLogin = this.IsLogin;
            var db = new MvcDB();
            var prod = db.Products.Where(x => x.ID == id).FirstOrDefault();
            return View(prod);
        }
    }
}
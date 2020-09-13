using Mvc.Eticaret.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc.Eticaret.UI.Web
{
    public class MvcControllerBase:Controller
    {
        //kullanıcı login kontrol
        public bool IsLogin { get; private set; }
        //giriş yapan user id
        public int LoginUserID { get; private set; }
        //login olan userin tüm bilgilerini buradan çekeceğim
        public User LoginUserEntity { get; private set; }
        protected override void Initialize(RequestContext requestContext)
        {
            //Session["LoginUserID"]
            //Session["LoginUser"]
            if (requestContext.HttpContext.Session["LoginUserID"]!=null)
            {
                //giriş yapıldı.
                IsLogin = true;
                LoginUserID = (int)requestContext.HttpContext.Session["LoginUserID"];
                LoginUserEntity = (Core.Model.Entity.User)requestContext.HttpContext.Session["LoginUser"];
            }


            base.Initialize(requestContext);
        }
    }
}
using CookieTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieTest.Controllers
{
    public class CookieController : Controller
    {
        private HttpCookie CreateCookie(string name, SameSiteMode sameSiteMode, bool isSecure, bool isHttpOnly)
        {
            var cookie = new HttpCookie(name, "CookieHasBeenSet");
            cookie.SameSite = sameSiteMode;
            cookie.Secure = isSecure;
            cookie.HttpOnly = isHttpOnly;
            cookie.Expires = DateTime.Now.AddDays(2);
            return cookie;
        }
        public ActionResult Index()
        {
            var cookiemodel = new CookiesModel() { CookieKeys = this.ControllerContext.HttpContext.Request.Cookies.AllKeys.ToList() };
            return View(cookiemodel);
        }
        
        public ActionResult Strict(bool isSecure = false, bool isHttpOnly = false)
        {
            var strictcookie = CreateCookie("StrictCookie", SameSiteMode.Strict, isSecure, isHttpOnly);           
            this.ControllerContext.HttpContext.Response.Cookies.Add(strictcookie);
            return View("Cookie", strictcookie.ToCookieInformationModel());
        }
        public ActionResult Lax(bool isSecure = false, bool isHttpOnly = false)
        {
            var laxcookie = CreateCookie("LaxCookie", SameSiteMode.Lax, isSecure, isHttpOnly);
            this.ControllerContext.HttpContext.Response.Cookies.Add(laxcookie);
            return View("Cookie", laxcookie.ToCookieInformationModel());
        }
        public ActionResult None(bool isSecure = false, bool isHttpOnly = false)
        {
            var nonecookie = CreateCookie("NoneCookie", SameSiteMode.None, isSecure, isHttpOnly);
            this.ControllerContext.HttpContext.Response.Cookies.Add(nonecookie);
            return View("Cookie", nonecookie.ToCookieInformationModel());
        }
    }
}
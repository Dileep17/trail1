using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace quotetrail.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [Authorize]
        public ActionResult Home()
        {

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Models.User User,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    return View(returnUrl);
                }
                if (User.IsValid(User.UserName))
                {
                    FormsAuthentication.SetAuthCookie(User.UserName, User.RememberMe);
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("","Login data is incorrect!");
                }
            }
            return View(User);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

    }
}

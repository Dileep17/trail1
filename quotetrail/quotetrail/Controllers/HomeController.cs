using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using quotetrail.Models;


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

        [Authorize]
        [HttpPost]
        public ActionResult AddQuote(Models.Quote quote)
        {
            quote.User = User.Identity.Name;
            quote.Status = quote.AddQuote() ? "added" : "failed";
            return PartialView("AddQuote", quote);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Home", "Home");
                }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Models.User User,string returnUrl)
        {
            if (ModelState.IsValid)
            {
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


        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetProjects()
        {
            var projectsList = new List<string> {"Abcam", "Pam", "Blue Label", "sathyam"};
            var x = Json(projectsList);
            return x;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetQuotes(string project)
        {
            var x =
                @" {""quotes"":[{""quote"": ""quote1 asd a sda sd as d a sda s dasd a sdasdasd asd"",""quoted_by"": ""JOHN"",""date"": ""13-JAN-2011""},{""quote"": ""sadasd a s asd asd a sd a sd a  sdada d a sd"",""quoted_by"": ""JOHN"",""date"": ""13-JAN-2011""},{""quote"": ""quote1 asd a sda sd as d a sda s dasd a sdasdasd asd"",""quoted_by"": ""JOHN"",""date"": ""13-JAN-2011""},{""quote"": ""sadasd a s asd asd a sd a sd a  sdada d a sd"",""quoted_by"": ""JOHN"",""date"": ""13-JAN-2011""}]}";
            

            return Json(x);

        }

    }
}

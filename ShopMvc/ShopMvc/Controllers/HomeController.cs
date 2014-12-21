using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                switch (Roles.GetRolesForUser(User.Identity.Name).First())
                {
                    case "Admin":
                        return RedirectToAction("Index", "Admin");
                        break;
                    case "Manager":
                        return RedirectToAction("Index", "Manager");
                        break;
                    case "Client":
                        return RedirectToAction("Index", "Client");
                        break;
                }
            } else
            return RedirectToAction("Login", "Account");

            return RedirectToAction("Login", "Account");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return RedirectToAction("Login", "Account");
        
        //}
    }
}

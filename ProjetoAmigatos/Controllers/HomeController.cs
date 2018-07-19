using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjetoAmigatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAmigatos.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        /*public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }*/

        /*public ActionResult UserData() {
            if (!Request.IsAuthenticated) {
                return Content("Not Authenticated");
            }

            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var userManager = new UserManager<ApplicationUser>(store);
            ApplicationUser user = userManager.FindByNameAsync(User.Identity.Name).Result;
            return Content("Id: " + User.Identity.Name + " Name: " + user.NomeCompleto);
        }*/
    }
}
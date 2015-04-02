using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Noralighting.com.Models;
using System.Web.Helpers;

namespace Noralighting.com.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                using (Entities3 db = new Entities3())
                {
                    
                    db.Users.Add(user);
                    db.SaveChanges();
                    ModelState.Clear();
                    user = null;
                    ViewBag.Message = "Successfully Registration Done";
                }
            }
            return View(user);
        }
    }
}
using Noralighting.com.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noralighting.com.App_Start
{
    private UserManager<MyIdentityUser> userManager;
    private RoleManager<MyIdentityRole> roleManager;
    
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        MyIdentityDbContext db = new MyIdentityDbContext();
 
    UserStore<MyIdentityUser> userStore = new UserStore<MyIdentityUser>(db);
    userManager = new UserManager<MyIdentityUser>(userStore);
 
    RoleStore<MyIdentityRole> roleStore = new RoleStore<MyIdentityRole>(db);
    roleManager = new RoleManager<MyIdentityRole>(roleStore);

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Register(Register model)
{
    if (ModelState.IsValid)
    {
        MyIdentityUser user = new MyIdentityUser();
 
        user.UserName = model.UserName;
        user.Email = model.Email;
        user.FullName = model.FullName;
        user.BirthDate = model.BirthDate;
        user.Bio = model.Bio;
 
        IdentityResult result = userManager.Create(user, model.Password);
 
        if (result.Succeeded)
        {
            userManager.AddToRole(user.Id, "Administrator");
            return RedirectToAction("Login","Account");
        }
        else
        {
            ModelState.AddModelError("UserName", "Error while creating the user!");
        }
    }
    return View(model);
    }
}

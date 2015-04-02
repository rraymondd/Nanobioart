using Noralighting.com.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Helpers;

namespace Noralighting.com.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        
        static List<User> Users = null;
        Entities3 db = new Entities3();
        
        public LoginController()
        {

            Users = db.Users.Cast<User>().ToList();
        }
 
        public ActionResult Index()
        {
            return View();
        }
 
        
        //Authentication using Crypto and AntiForgeryToken
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(User tempUser, string ReturnUrl)
        {
           

                if (ModelState.IsValid)
                {

                    User user = Users.FirstOrDefault(x => x.UserName == tempUser.UserName);
                    if (user != null)
                    {

                        if (ValidateCredentials(tempUser.UserName, tempUser.Password))
                        {
                            Session["User"] = user;
                            FormsAuthentication.SetAuthCookie(user.UserName, tempUser.RememberMe);
                            if (ReturnUrl == null)
                            {
                                return Redirect("Home");
                            }
                            else
                            {
                                return Redirect(ReturnUrl);
                            }

                        }

                        else
                        {
                            ModelState.AddModelError("", "Log In Failed");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Log In Failed");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Log In Failed");
                }
            
                return View();
            
        }

        /* We don’t want to use the normal string comparison (== operator) when comparing password values. 
         * The reason is that normal string comparison will exit as soon as the first character mismatch is 
         * encountered and this can leak information to an attacker. Fortunately the implementation inside 
         * of Crypto.VerifyHashedPassword does not use the normal string comparison and always does a full 
          character-by-character comparison to not leak this side channel information.*/

        public bool ValidateCredentials(string username, string password)
        {
            var hashedPassword = FindByUserName(username);
            var doesPasswordMatch = Crypto.VerifyHashedPassword(hashedPassword, password);
            return doesPasswordMatch;
        }

        
        // Get the password of a user by providing the username
        public string FindByUserName(string username)
        {
            var query = from user in db.Users
                            where user.UserName == username
                            select user;
            return query.Single().Password;
        }
    }

    }


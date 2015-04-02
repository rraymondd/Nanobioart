using Noralighting.com.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noralighting.com.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        Entities1 db = new Entities1();

        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        
	}
}
using Noralighting.com.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Noralighting.com.Controllers
{
    public class ItemController : Controller
    {
        //
        // GET: /Contact/
      Entities db = new Entities();
    
             
      public ActionResult Index(string tags, int page=1)

        {
            

            if (tags == null)
            {
                 return View(db.Products.OrderBy(p => p.ItemCode).ToPagedList(page, 10));
            }

            
            else if(tags == "")
            {
                page = 1;
                return View(db.Products.OrderBy(p => p.ItemCode).ToPagedList(page, 10));
            }
     


            else
            {
               
                page = 1;
                var products2 = from x in db.Products where x.ItemCode == tags select x;
                return View(products2.OrderBy(p => p.ItemCode).ToPagedList(page, 10));
            }

            }

      public ActionResult TagSearch(string term)
      {
          // Get Tags from database
          var result = (from p in db.Products where p.ItemCode.ToLower().StartsWith(term.ToLower()) select new { p.ItemCode }).Distinct();
          return Json(result, JsonRequestBehavior.AllowGet);
      }

      
          }
      }

        

    


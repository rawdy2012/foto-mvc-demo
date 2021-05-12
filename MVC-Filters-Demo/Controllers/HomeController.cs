using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Filters_Demo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        
        public ActionResult GetDate()
        {
            return View();
        }
        [OutputCache(Duration = 20)]
        public string GetDay()
        {
            var result= DateTime.Now.DayOfWeek;
            return result.ToString();
        }
    }
}
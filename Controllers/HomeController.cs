using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADToBSDateConverter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string Date)
        {
            NepaliDate nDate = new NepaliDate();
            string nepDate = "";
            if (Date!=null && Date.Length > 0)
            {
                DateTime engDate = Convert.ToDateTime(Date);
                nepDate = nDate.getNepaliDate(engDate);
            }
            ViewBag.NepaliDate = nepDate;
            ViewBag.EnglishDate = Date;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smile.BLL;
using Smile.DAL.Repositories;


namespace Smile.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var db = new SmileData("SmileContext");
            return View(db.Orders.GetAll());
        }
    }
}
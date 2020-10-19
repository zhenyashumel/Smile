using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Smile.BLL;
using Smile.BLL.Telegram;
using Smile.DAL.Repositories;


namespace Smile.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {

            var db = new SmileData("SmileContext");
            await Bot.BotInit();
            Bot.Get();
            //await Bot.SendInfo();
            return View(db.Orders.GetAll());

        }
    }
}
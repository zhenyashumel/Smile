using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Smile.BLL;
using Smile.BLL.Telegram;
using Smile.DAL.Repositories;
using Smile.Entities;


namespace Smile.Web.Controllers
{
    public class HomeController : Controller
    {
        private SmileData db;
        private bool _admin;
        private string _login;
        private string _password;

        public HomeController()
        {
            db = new SmileData("SmileContext");
            _login = "Artulybka";
            _password = "Hello";
        }
        public ActionResult Index()
        {

            
            //await Bot.BotInit();
            //Bot.Get();
            //await Bot.SendInfo();
            return View(db.Employees.GetAll());
        }

        [HttpGet]
        public ActionResult MakeOrder()
        {
            ViewBag.Languages = new SelectList(db.Languages.GetAll(), "Id", "Lang");
            ViewBag.Characters = new SelectList(db.Characters.GetAll(),"Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult MakeOrder(Order order)
        {
            order.Raiting = 0;
            order.InProgress = true;
            db.Orders.Create(order);
            db.Save();
            Response.Write("<script>alert('Спасибо за заявку. В ближайшее время наш менеджер с Вами свяжется!')</script>");
            return View("Index");
        }

        [HttpGet]
        public ActionResult Authorize()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(string login, string password)
        {
            if (login == _login && password == _password)
            {
                _admin = true;
                return View("GetOrdersInfo", db.Orders.Find(o => o.InProgress));
            }
            Response.Write("<script>alert('Неверный логин или пароль')</script>");

            return View("Authorize");
        }

        public ActionResult GetOrdersInfo()
        {
            if (!_admin)
                return View("Index");

            return View(db.Orders.Find(o=>o.InProgress));
        }

        public ActionResult Choose(int id)
        {
            
            var order = db.Orders.Get(id);

            var employee =EmployeesService.ChooseEmployees(db, order.Date,order.Language, order.Character);
            if (employee is null || !employee.Any())
            {
                Response.Write("<script>alert('Аниматоры не найдены!')</script>");
                return View("GetOrdersInfo");
            }

            var message = $"Дата: {order.Date:dd:MM}{Environment.NewLine}" +
                             $"Продолжительность: {order.Time:mm\\:ss} {Environment.NewLine}" +
                             $"Персонаж: {order.Character.Name} {Environment.NewLine}" +
                             $"Язык: {order.Language.Lang}";
            Task.Run(()=>Bot.SendInfo(Convert.ToInt32(employee.First().Contact), message));
            return View("Index");
        }

    }
}
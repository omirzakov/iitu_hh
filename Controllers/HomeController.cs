using iitu_project_hh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Telegram.Bot;

namespace iitu_project_hh.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [Authorize(Roles ="Admin, User")]
        public ActionResult About()
        {
            ViewBag.Message = "О нас";

            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(string ProjectName, 
            string Name, string Sname, string Age, string Photo, string Skills, string Phone, string Email, string ExtraInfo)
        {
            try
            {
                string email = "\uD83D\uDCE7";
                string phone = "\uD83D\uDCDE";
                string exclamation = "\uFF01";

                String text = "Заявление на вступление в проект! " + exclamation + "\n" +
                              "Название проекта: " + ProjectName + "\n" +
                              "Имя: " + Name + "\n" +
                              "Фамилия: " + Sname + "\n" +
                              "Возраст: " + Age + "\n" +
                              "Навыки: " + Skills + "\n" +
                              "Ссылка фотографии" + Photo + "\n" +
                              "Номер телефона: " + Phone + " " + phone + "\n" +
                              "Почта: " + Email + " " + email + "\n" +
                              "Дополнительная информация: " + ExtraInfo;
                var Bot = new TelegramBotClient("1471764690:AAGgrvsAoF13ER4ywazmMYFnYlOiOlA6bVY");
                var s = Bot.SendTextMessageAsync("@hh_iitu", text);
            }
            catch(Exception e)
            {
                Console.WriteLine("err");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
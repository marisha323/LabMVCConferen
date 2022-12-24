using LabMVCConferen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using System;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace LabMVCConferen.Controllers
{
    public class HomeController : Controller
    {
        
        ConferensContext context;
        [BindProperty]
        public User user { get; set; }
        public Conferens conferens  { get; set; }
        public HomeController(ConferensContext db)
        {
            this.context = db;

        }
        [HttpPost]
        public async Task<ActionResult> Index(string email,string password)
        {
            //string Log = textBox1.Text;
            //string password = textBox2.Text;
            //if (db.Regestrs.Where(o => o.Login.Equals(Log) && o.Password.Equals(password)).Count() != 0)
            //{
            //    Form1 form1 = new Form1();
            //    Visible = false;
            //    form1.ShowDialog();
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Ви не можете війти тому що, Ви не адміністратор або невірний Логін чи Пароль");
            //}
            user = context.Users.Where(o => o.Email.Equals(email) && o.Password.Equals(password)).FirstOrDefault();
            if (user!=null)
            {
                if (user.RoleId==2)
                {
                    return Redirect("/ConferensZap/Index");
                }
                if (user.RoleId==1)
                {
                    return Redirect("/ConferenceForRegistered/Index");
                }
            }
            return View();
        }
        [HttpPost]

        public async Task<ActionResult> Regist([Bind] User user2)
        {
            //user = context.Users.Where(o => o.Id == user2.Id).FirstOrDefault();
            //user.Email=user2.Email;

            //user = context.Users.Where(o => o.Phone == user2.Phone).FirstOrDefault();
            //user = context.Users.Where(o => o.Email == user2.Email).FirstOrDefault();
            //user = context.Users.Where(o => o.Password == user2.Password).FirstOrDefault();
            //user = context.Users.Where(o=>o.RoleId==)
            //ll199411111@gmail.com
            user2.RoleId = context.Roles.Where(o => o.Name.Equals("user")).FirstOrDefault().Id;
            context.Users.Add(user2);
            await context.SaveChangesAsync();
            Random rand = new Random();
            var num = rand.Next(1000, 9999);
            var fromAddress = new MailAddress("robottester51@gmail.com", "Conferens");
            const string fromPassword = "iokkbczukalzztuv";
            var toAddress = new MailAddress(user2.Email, $"{user2.Name}");
            const string subject = "Change Password";
            string body = $"<h1>Hello this is the message to reset you're password!\nHere is you're code: [{num}]</h1>";
            var smtp = new SmtpClient { Host = "smtp.gmail.com", Port = 587, EnableSsl = true, DeliveryMethod = SmtpDeliveryMethod.Network, Credentials = new NetworkCredential(fromAddress.Address, fromPassword), Timeout = 20000 };
            using (var message = new MailMessage(fromAddress, toAddress)
            { Subject = subject, Body = body })
            { smtp.Send(message);
            }; 
            return RedirectToAction("Sanks","Home",new { number=num});
        }
        public async Task<ActionResult> CodСonfirmation(string cod,string rait)
        {
            if (cod.Equals(rait))
            {
                return Redirect("/ConferencClient/Index");
            }
            return Redirect("/Home/Sanks");
        }
        public IActionResult Index()
        {
            return View(user);
        }
        public IActionResult Sanks(int number)
        {
            ViewData["number"]=number;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
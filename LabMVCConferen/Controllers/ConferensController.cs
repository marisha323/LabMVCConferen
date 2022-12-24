using LabMVCConferen.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabMVCConferen.Controllers
{
    public class ConferensController : Controller
    {
        ConferensContext context;
        [BindProperty]
        public User? user { get; set; }

        public ConferensController(ConferensContext db)
        {
            this.context = db;

        }

        public IActionResult Index()
        {
            //Role role = new Role() { Name="admin"};
            //Role role1 = new Role() { Name = "user" };
            //user = new User() { Name = "Fader", Email="feder23@gmail.com", Phone="0985436644", Password= "1234" };
            //context.Roles.Add(role1);
            //context.Roles.Add(role);
            //context.SaveChanges();
            //context.Users.Add(user);
            //context.SaveChanges();
            return View();
        }
       
    }
}

using LabMVCConferen.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabMVCConferen.Controllers
{
    public class ConferenceForRegisteredController : Controller
    {
        ConferensContext context;
        public Conferens conferens  { get; set; }
        public ConferenceForRegisteredController(ConferensContext db)
        {
            this.context = db;

        }
        public IActionResult Index()
        {
            return View(context.Conferens.ToList());
        }
        public IActionResult Zapolnenia()
        {
            return Redirect("/ConferenceZap/Index");
        }
    }
}

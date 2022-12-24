using LabMVCConferen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabMVCConferen.Controllers
{
    public class ConferensZap : Controller
    {
        // GET: ConferensZap

        ConferensContext context;
        [BindProperty]
        public Conferens conferens { get; set; }
        public ConferensZap(ConferensContext db)
        {
            this.context = db;

        }
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index([Bind] Conferens conferens1)
        {
            context.Conferens.Add(conferens1);
            await context.SaveChangesAsync();
            return Redirect("/ConferenceForRegistered/Index");
        }
            // GET: ConferensZap/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConferensZap/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConferensZap/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConferensZap/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConferensZap/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConferensZap/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConferensZap/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

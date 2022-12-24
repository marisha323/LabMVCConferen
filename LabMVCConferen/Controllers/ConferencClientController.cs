using LabMVCConferen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabMVCConferen.Controllers
{
    public class ConferencClientController : Controller
    {
        // GET: ConferencClientController
        ConferensContext context;
        public Conferens conferens { get; set; }
        public ConferencClientController(ConferensContext db)
        {
            this.context = db;

        }
        public ActionResult Index()
        {
            return View(context.Users.ToList());
        }

        // GET: ConferencClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConferencClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConferencClientController/Create
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

        // GET: ConferencClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConferencClientController/Edit/5
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

        // GET: ConferencClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConferencClientController/Delete/5
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

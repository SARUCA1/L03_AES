using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class SATController : Controller
    {
        // GET: SATController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SATController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SATController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SATController/Create
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

        // GET: SATController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SATController/Edit/5
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

        // GET: SATController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SATController/Delete/5
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

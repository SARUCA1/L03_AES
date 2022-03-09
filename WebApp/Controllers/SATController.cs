using CsvHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Helpers;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SATController : Controller
    {
        // GET: SATController
        public ActionResult Index()
        {
            return View();//Data.Instance.Lista;
        }

        [HttpGet]
        public IActionResult Index(List<SATModel> Lista = null)
        {
            Lista = Lista == null ? new List<SATModel>() : Lista;
            return View(Lista);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }

            var Lista = this.GetTeamList(file.FileName);

            return Index(Lista);
        }
        private List<SATModel> GetTeamList(string fileName)
        {
            List<SATModel> Lista = new List<SATModel>();

            var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fileName;
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var lista = csv.GetRecord<SATModel>();
                    Data.Instance.Lista.Insertar(lista);
                }
            }

            return Lista;
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
                SATModel.Save(new SATModel
                {
                    ID = collection["ID"],
                    Email = collection["Email"],
                    Propietario = collection["Propietario"],
                    Color = collection["Color"],
                    Marca = collection["Marca"],
                    Serie = collection["Serie"],
                });
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

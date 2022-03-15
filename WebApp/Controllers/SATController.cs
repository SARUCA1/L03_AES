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
            return View(Data.Instance.Lista);//Data.Instance.Lista;
        }

        [HttpGet]
        public IActionResult Index(List<SATModel> List = null)
        {
            List ??= new List<SATModel>();
            return View(List);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            #region Upload CSV
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            #endregion
            var modelo = this.GetList(file.FileName);

            return View(Data.Instance.Lista);
        }
        private List<SATModel> GetList(string fileName)
        {
            List<SATModel> Lista = new List<SATModel>();
            #region Read CSV
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
                    //Lista.Add(lista);
                }
            }
            #endregion

            //#region Create CSV
            //path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}";
            //using (var write = new StreamWriter(path + "\\NewFile.csv"))
            //using (var csv = new CsvWriter(write, CultureInfo.InvariantCulture))
            //{
            //    csv.WriteRecord(Lista);
            //}
            //#endregion

            //return Data.Instance.Lista;
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
                var informacio = SATModel.Save(new SATModel
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

        public ActionResult PreOrder()
        {
            return View();
        }

        public ActionResult InOrder()
        {
            return View();
        }

        public ActionResult PostOrder()
        {
            return View();
        }
    }
}

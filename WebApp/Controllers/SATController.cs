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
using System.Diagnostics;

namespace WebApp.Controllers
{
    public class SATController : Controller
    {

        //StopWatch 
        double tiempo;
        double  OrdenamientoT;
        Stopwatch Time = new Stopwatch();
        Stopwatch TimeOrder = new Stopwatch();

        // GET: SATController
        public ActionResult Index(ArbolB<SATModel> lista)
        {
            ViewBag.Message = "El tiempo de carga es de: " +tiempo +" Milisegundos";
            ViewData["Message"] = "El tiempo de ordenamiento de datos es de: " +OrdenamientoT+ " Milisegundos";

            return View(Data.Instance.Lista);//Data.Instance.Lista;
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

            var Lista = this.GetList(file.FileName);

            return Index(Lista);
        }
        private List<SATModel> GetList(string fileName)
        {
            Time.Start();
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
                    TimeOrder.Start();
                    Data.Instance.Lista.Insertar(lista, Comparar.CompEmail);
                    Data.Instance.ArbolID.Insertar(lista, Comparar.CompID);
                    Data.Instance.ArbolSerial.Insertar(lista, Comparar.CompSerial);

                    Data.Instance.AvlMail.Insertar(lista, Comparar.CompEmail);
                    Data.Instance.AvlID.Insertar(lista, Comparar.CompID);
                    Data.Instance.AvlSerial.Insertar(lista, Comparar.CompSerial);

                }
                TimeOrder.Stop();
            }
            #endregion

            Time.Stop();
            tiempo = Time.Elapsed.TotalMilliseconds;
            OrdenamientoT = TimeOrder.Elapsed.TotalMilliseconds;
            return Data.Instance.Lista;
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

        public ActionResult Email()
        {
            return View(Data.Instance.Lista);
        }

        public ActionResult ID()
        {
            return View(Data.Instance.ArbolID);
        }

        public ActionResult Serial()
        {
            return View(Data.Instance.ArbolSerial);
        }
    }
}

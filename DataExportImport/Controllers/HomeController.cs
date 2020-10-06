using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataExportImport.Models;
using DataExportImport.Service;
using Newtonsoft.Json;

namespace DataExportImport.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Customer()
        {
            Customer cus = new Customer();
            cus = (Customer)TempData["data"];
            ViewData["data"] = TempData["data"];
            return View(cus);
        }

        public ActionResult Export(Customer customer)
        {
            var exportDataintoJsonFile = new ExportDataintoJsonFile();
            exportDataintoJsonFile.GenerateJsonFile(customer);
            ModelState.Clear();
            return View("Customer");
        }

        public ActionResult CustomerOwnedVehicle()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Customer(Customer customer)
        {
            var dbContext = new DbContext();
            dbContext.save(customer);
            return View();
        }

        [HttpPost]
        public ActionResult Import(HttpPostedFileBase file)
        {
            var path = Server.MapPath("~/Uploads/");
            if (file != null)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                var filePath = path + Path.GetFileName(file.FileName);
                file.SaveAs(filePath);

                var jsonData = System.IO.File.ReadAllText(filePath);
                var myDetails = JsonConvert.DeserializeObject<Customer>(jsonData);

                TempData["data"] = myDetails;
                return RedirectToAction("Customer");
            }
            return RedirectToAction("Customer");
        }
    }
}
using System.IO;
using System.Web;
using System.Web.Mvc;
using DataExportImport.Models;
using DataExportImport.Service;
using Newtonsoft.Json;

namespace DataExportImport.Controllers
{
    public class HomeController : Controller
    {
        [HandleError]
        public ActionResult Customer()
        {
            var customer = (Customer)TempData["data"];
            ViewData["data"] = TempData["data"];
            return View(customer);
        }

        public ActionResult Export(Customer customer)
        {
            var exportDataIntoJsonFile = new ExportDataIntoJsonFile();
            exportDataIntoJsonFile.GenerateJsonFile(customer);
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
            dbContext.Save(customer);
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
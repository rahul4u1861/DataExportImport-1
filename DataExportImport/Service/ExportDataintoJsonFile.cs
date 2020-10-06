using System;
using System.IO;
using System.Web.Script.Serialization;

namespace DataExportImport.Service
{
    public class ExportDataIntoJsonFile
    {
        public string GenerateJsonFile(object obj)
        {
            var path = @"C:\Hackathon";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var jsonData = new JavaScriptSerializer().Serialize(obj);
            var fileName = @"\output_" + DateTime.Now.ToString("dd'-'MM'-'yyyy_HH_mm_ss_fff") + ".json";
            File.WriteAllText(path + fileName, jsonData);

            return "Json file Generated! check this in your App_Data folder";
        }
    }
}
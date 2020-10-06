using System;
using System.IO;
using System.Web.Script.Serialization;

namespace DataExportImport.Service
{
    public class ExportDataintoJsonFile
    {
        public string GenerateJsonFile(object obj)
        {
            string path = @"C:\Hackathon";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string jsondata = new JavaScriptSerializer().Serialize(obj);
            string fileName = @"\output_" + DateTime.Now.ToString("dd'-'MM'-'yyyy_HH_mm_ss_fff") + ".json";
            File.WriteAllText(path + fileName, jsondata);

            return "Json file Generated! check this in your App_Data folder";
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using t4_pr1_LlucVelazquez.Model;
using FileWorking = System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Formats.Asn1;
using CsvHelper;

namespace t4_pr1_LlucVelazquez.Pages
{
    public class WaterConsumeModel : PageModel
    {
        public string FileErrorMessage;
        public List<WaterConsume> WaterConsumes { get; set; } = new List<WaterConsume>();
        public void OnGet()
        {
            string CsvFilePath = @"ModelData\consum_aigua_cat_per_comarques.csv";
            if (System.IO.File.Exists(CsvFilePath))
            {
                using var reader = new StreamReader(CsvFilePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                WaterConsumes = csv.GetRecords<WaterConsume>().ToList();
            }
            else 
            {
                FileErrorMessage = "Error de carrega de dades";
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FileWorking = System.IO;
using t4_pr1_LlucVelazquez.Model;
using System.Globalization;
using CsvHelper;

namespace t4_pr1_LlucVelazquez.Pages
{
    public class EnergyIndicatorsModel : PageModel
    {
        public string FileErrorMessage;
        public List<EnergyIndicator> EnergyIndicators { get; set; } = new List<EnergyIndicator>();
        public void OnGet()
        {
            string CsvFilePath = @"ModelData\indicadors_energetics_cat.csv";
            if (FileWorking.File.Exists(CsvFilePath))
            {
                using var reader = new StreamReader(CsvFilePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                EnergyIndicators = csv.GetRecords<EnergyIndicator>().ToList();
            }
            else
            {
                FileErrorMessage = "Error de carrega de dades";
            }
        }
    }
}

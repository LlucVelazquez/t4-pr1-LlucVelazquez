using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FileWorking = System.IO;
using t4_pr1_LlucVelazquez.Model;
using System.Globalization;
using CsvHelper;
using System.Diagnostics;

namespace t4_pr1_LlucVelazquez.Pages
{
    public class EnergyIndicatorsModel : PageModel
    {
        public string FileErrorMessage;
        public List<EnergyIndicator> EnergyIndicators { get; set; } = new();
        public List<EnergyIndicator> NetProductionAbove3000 => EnergyIndicators.Where(i => i.CDEEBC_ProdNeta > 3000).OrderBy(i => i.CDEEBC_ProdNeta).ToList();
        public List<EnergyIndicator> GasConsumMore100 => EnergyIndicators.Where(i => i.CCAC_GasolinaAuto > 100).OrderByDescending(i => i.CCAC_GasolinaAuto).ToList();
        public List<(int any, decimal mitjanaProduccioNeta)> ProductionAverageForYear => EnergyIndicators.GroupBy(i => i.Data.Year)
                     .Select(g => (any: g.Key, mitjanaProduccioNeta: g.Average(i => i.CDEEBC_ProdNeta))).OrderBy(r => r.any).ToList();
        public List<EnergyIndicator> ElectricalDemand => EnergyIndicators.Where(i => i.CDEEBC_DemandaElectr > 4000 && i.CDEEBC_ProdDisp < 300).ToList();
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

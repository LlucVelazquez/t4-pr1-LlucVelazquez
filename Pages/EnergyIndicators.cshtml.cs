using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FileWorking = System.IO;
using t4_pr1_LlucVelazquez.Model;
using System.Globalization;
using CsvHelper;
using System.Diagnostics;
using System.Text.Json;

namespace t4_pr1_LlucVelazquez.Pages
{
    public class EnergyIndicatorsModel : PageModel
    {
        public string FileErrorMessage;
        public List<EnergyIndicator> EnergyIndicators { get; set; } = new();

        public List<EnergyIndicator> EnergyIndicators2 { get; set; } = new();
		public List<EnergyIndicator> EnergyIndicators3 { get; set; } = new();
		public List<EnergyIndicator> NetProductionAbove3000 => EnergyIndicators.Where(i => i.CDEEBC_ProdNeta > 3000).OrderBy(i => i.CDEEBC_ProdNeta).ToList();
        public List<EnergyIndicator> GasConsumMore100 => EnergyIndicators.Where(i => i.CCAC_GasolinaAuto > 100).OrderByDescending(i => i.CCAC_GasolinaAuto).ToList();
        public List<(int any, decimal mitjanaProduccioNeta)> ProductionAverageForYear => EnergyIndicators.GroupBy(i => i.Data.Year)
                     .Select(g => (any: g.Key, mitjanaProduccioNeta: g.Average(i => i.CDEEBC_ProdNeta))).OrderBy(r => r.any).ToList();
        public List<EnergyIndicator> ElectricalDemand => EnergyIndicators.Where(i => i.CDEEBC_DemandaElectr > 4000 && i.CDEEBC_ProdDisp < 300).ToList();
        public void OnGet()
        {
            string jsonFile = FileWorking.File.ReadAllText(@"ModelData\indicadors_energetics_cat.json");
			string CsvFilePath = @"ModelData\indicadors_energetics_cat.csv";
            if (FileWorking.File.Exists(CsvFilePath))
            {
                using var reader = new StreamReader(CsvFilePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                EnergyIndicators3 = csv.GetRecords<EnergyIndicator>().ToList();
                string JsonFilePath = @"ModelData\indicadors_energetics_cat.json";
                if (jsonFile != "")
				{
					using var reader2 = new StreamReader(JsonFilePath);
					string jsonString = reader2.ReadToEnd();
					EnergyIndicators2 = JsonSerializer.Deserialize<List<EnergyIndicator>>(jsonString);
					EnergyIndicators = EnergyIndicators3.Concat(EnergyIndicators2).ToList();

				} else
                {
					EnergyIndicators = EnergyIndicators3;
				}
				
			}
            else
            {
                FileErrorMessage = "Error de carrega de dades";
            }
        }
    }
}

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
    public class SimulationsModel : PageModel
    {
		private const string CsvFilePath = @"ModelData\simulacions_energia.csv";
		public List<Simulation> Products { get; set; } = new List<Simulation>();
		public void OnGet()
        {
			using StreamReader reader = new StreamReader(CsvFilePath);
			using CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

			var records = csvReader.GetRecords<Simulation>();

			foreach (var record in records)
			{
				Console.WriteLine($"{record.Date}, {record.TypeSim}, {record.Valor}, {record.Rati}, {record.EnergyGen}, {record.Cost}, {record.Preu}, {record.CostTotal}, {record.PreuTotal}");
			}
		}
    }
}

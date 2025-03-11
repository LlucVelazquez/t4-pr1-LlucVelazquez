using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using t4_pr1_LlucVelazquez.Model;
using FileWorking = System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Formats.Asn1;
using CsvHelper;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace t4_pr1_LlucVelazquez.Pages
{
    public class WaterConsumeModel : PageModel
    {
        public string FileErrorMessage;
        public List<WaterConsume> WaterConsumes { get; set; } = new List<WaterConsume>();
        public void OnGet()
        {
            string CsvFilePath = @"ModelData\consum_aigua_cat_per_comarques.csv";
            if (FileWorking.File.Exists(CsvFilePath))
            {
                using var reader = new StreamReader(CsvFilePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                WaterConsumes = csv.GetRecords<WaterConsume>().ToList();
            }
            else 
            {
                FileErrorMessage = "Error de carrega de dades";
            }
            var consums = new List<WaterConsume>();
            var xmlDoc = XDocument.Load(@"ModelData\consum_aigua_cat_per_comarques.xml");

            foreach (var element in xmlDoc.Root.Elements())
            {
                consums.Add(new WaterConsume
                {
                    Year = int.Parse(element.Element("Year").Value),
                    Code = int.Parse(element.Element("Code").Value),
                    Region = element.Element("Region").Value,
                    Population = int.Parse(element.Element("Population").Value),
					DomesticNetwork = int.Parse(element.Element("DomesticNetwork").Value),
					EconomicActOwnSource = int.Parse(element.Element("EconomicActOwnSource").Value),
                    Total = int.Parse(element.Element("Total").Value),
                    HouseholdConsumCapita = decimal.Parse(element.Element("HouseholdConsumCapita").Value)
                });
            }
            WaterConsumes = WaterConsumes.Concat(consums).ToList();
        }
    }
}

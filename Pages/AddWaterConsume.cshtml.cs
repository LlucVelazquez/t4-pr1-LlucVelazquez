using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using t4_pr1_LlucVelazquez.Model;
using System.Xml;
using System.Xml.Linq;

namespace t4_pr1_LlucVelazquez.Pages
{
    public class AddWaterConsumeModel : PageModel
    {
        [BindProperty]
        public WaterConsume NewWaterConsume { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
			string filePath = @"ModelData\consum_aigua_cat_per_comarques.xml";
			XDocument doc = XDocument.Load(filePath);
			XElement element = doc.Element("Consumes");
			       element.Add(new XElement("waterConsume",
				   new XElement("Year", NewWaterConsume.Year),
				   new XElement("Code", NewWaterConsume.Code),
				   new XElement("Region", NewWaterConsume.Region),
				   new XElement("Population", NewWaterConsume.Population),
				   new XElement("DomesticNetwork", NewWaterConsume.DomesticNetwork),
				   new XElement("EconomicActOwnSource", NewWaterConsume.EconomicActOwnSource),
				   new XElement("Total", NewWaterConsume.Total),
				   new XElement("HouseholdConsumCapita", NewWaterConsume.HouseholdConsumCapita)
				   ));
			   doc.Save(filePath); 
			return RedirectToPage("WaterConsume");
        }
    }
}

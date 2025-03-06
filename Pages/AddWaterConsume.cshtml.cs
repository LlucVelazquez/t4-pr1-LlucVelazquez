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
			/*XmlDocument xmlDocument = new XmlDocument();
			XmlElement consumesElement = xmlDocument.CreateElement("Cosa");
            xmlDocument.AppendChild(consumesElement);

            XmlElement waterElement = xmlDocument.CreateElement("Consume");
            consumesElement.AppendChild(waterElement);

			AddChildElementInt(xmlDocument, waterElement, "Year", NewWaterConsume.Year);
			AddChildElementInt(xmlDocument, waterElement, "Code", NewWaterConsume.Code);
			AddChildElement(xmlDocument, waterElement, "Region", NewWaterConsume.Region);
			AddChildElementInt(xmlDocument, waterElement, "Population", NewWaterConsume.Population);
			AddChildElementInt(xmlDocument, waterElement, "DomesticNetwork", NewWaterConsume.DomesticNetwork);
			AddChildElementInt(xmlDocument, waterElement, "EconomicActOwnSource", NewWaterConsume.EconomicActOwnSource);
			AddChildElementInt(xmlDocument, waterElement, "Total", NewWaterConsume.Total);
			AddChildElementDecimal(xmlDocument, waterElement, "HouseholdConsumCapita", NewWaterConsume.HouseholdConsumCapita);

			string filePath = @"ModelData\consum_aigua_cat_per_comarques.xml";
			xmlDocument.Save(filePath);


			static void AddChildElement(XmlDocument xmlDoc, XmlElement parentElement, string elementName, string value)
			{
				XmlElement childElement = xmlDoc.CreateElement(elementName);
				childElement.InnerText = value;
				parentElement.AppendChild(childElement);
			}
			static void AddChildElementInt(XmlDocument xmlDoc, XmlElement parentElement, string elementName, int value)
			{
				XmlElement childElement = xmlDoc.CreateElement(elementName);
				childElement.InnerText = value.ToString();
				parentElement.AppendChild(childElement);
			}
			static void AddChildElementDecimal(XmlDocument xmlDoc, XmlElement parentElement, string elementName, decimal value)
			{
				XmlElement childElement = xmlDoc.CreateElement(elementName);
				childElement.InnerText = value.ToString();
				parentElement.AppendChild(childElement);
			}*/
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
			/*
			   string filePath = @"ModelData\consum_aigua_cat_per_comarques.xml";
			   string? waterConsumeS = $"{NewWaterConsume.Year},{NewWaterConsume.Code},{NewWaterConsume.Region},{NewWaterConsume.Population}" +
				   $",{NewWaterConsume.DomesticNetwork},{NewWaterConsume.EconomicActOwnSource},{NewWaterConsume.Total},{NewWaterConsume.HouseholdConsumCapita}";
			   if (System.IO.File.Exists(filePath))
			   {
				   System.IO.File.AppendAllText(filePath, waterConsumeS + Environment.NewLine);
			   }
			   else
			   {
				   Debug.WriteLine("No trobo el fitxer");
			   }*/
			return RedirectToPage("WaterConsume");
        }
    }
}

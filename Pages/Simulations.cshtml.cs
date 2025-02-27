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
		public List<Simulation> Simulations { get; set; } = new List<Simulation>();
		public void OnGet()
        {
			string CsvFilePath = @"ModelData\simulacions_energia.csv";

			string[] lines = FileWorking.File.ReadAllLines(CsvFilePath);
			foreach (string line in lines)
			{
				string[] parts = line.Split(',');
				if(parts.Length == 9)
				{
					Simulation simulation = new Simulation();
					simulation.Date = DateTime.Parse(parts[0]);
					simulation.TypeSim = parts[1];
					simulation.Valor = float.Parse(parts[2]);
					simulation.Rati = float.Parse(parts[3]);
					simulation.EnergyGen = float.Parse(parts[4]);
					simulation.Cost = decimal.Parse(parts[5]);
					simulation.Preu = decimal.Parse(parts[6]);
					simulation.CostTotal = decimal.Parse(parts[7]);
					simulation.PreuTotal = decimal.Parse(parts[8],CultureInfo.InvariantCulture);
					Simulations.Add(simulation);
				}
			}
		}
    }
}

/*
 simulacions_energia.csv header : Date,TypeSim,Valor,Rati,EnergyGen,Cost,Preu,CostTotal,PreuTotal
*/
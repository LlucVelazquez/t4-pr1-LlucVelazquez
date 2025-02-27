using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using t4_pr1_LlucVelazquez.Model;

namespace t4_pr1_LlucVelazquez.Pages
{
    public class AddSimulationModel : PageModel
    {
        [BindProperty]
        public Simulation NewSimulation { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string filePath = @"ModelData\simulacions_energia.csv";
            string? simulationS = $"{NewSimulation.Date = DateTime.Now},{NewSimulation.TypeSim}," +
                $"{NewSimulation.Valor},{NewSimulation.Rati},{NewSimulation.EnergyGen},{NewSimulation.Cost},{NewSimulation.Preu}," +
                $"{NewSimulation.CostTotal = NewSimulation.Cost * ((decimal)NewSimulation.EnergyGen)}," +
                $"{NewSimulation.PreuTotal = NewSimulation.Preu * ((decimal)NewSimulation.EnergyGen)}";
            if(System.IO.File.Exists(filePath))
            {
                System.IO.File.AppendAllText(filePath, simulationS + Environment.NewLine);
            } else
            {
				Debug.WriteLine("No trobo el fitxer");
			}
			return RedirectToPage("Simulations");
		}
    }
}

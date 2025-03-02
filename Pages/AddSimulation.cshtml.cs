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
            double energy = 0;
            double cabalAigua = 9.8D;
            if (NewSimulation.TypeSim == "Sistema Solar") { energy = NewSimulation.Valor * NewSimulation.Rati; }
            else if (NewSimulation.TypeSim == "Sistema Eolic") { energy = Math.Pow(NewSimulation.Valor, 3) * NewSimulation.Rati; }
            else if(NewSimulation.TypeSim == "Sistema Hidroelectric") { energy = NewSimulation.Valor * cabalAigua * NewSimulation.Rati; }
                string? simulationS = $"{NewSimulation.Date = DateTime.Now},{NewSimulation.TypeSim}," +
                    $"{NewSimulation.Valor},{NewSimulation.Rati},{NewSimulation.EnergyGen = energy},{NewSimulation.Cost},{NewSimulation.Preu}," +
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

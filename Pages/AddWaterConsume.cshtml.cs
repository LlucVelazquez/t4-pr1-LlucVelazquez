using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using t4_pr1_LlucVelazquez.Model;

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
            string? waterConsumeS = $"{NewWaterConsume.Year},{NewWaterConsume.Year},{NewWaterConsume.Region},{NewWaterConsume.Population}" +
                $",{NewWaterConsume.DomesticNetwork},{NewWaterConsume.EconomicActOwnSource},{NewWaterConsume.Total},{NewWaterConsume.HouseholdConsumCapita}";
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.AppendAllText(filePath, waterConsumeS + Environment.NewLine);
            }
            else
            {
                Debug.WriteLine("No trobo el fitxer");
            }
            return RedirectToPage("WaterConsume");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using t4_pr1_LlucVelazquez.Model;
using System.Diagnostics;

namespace t4_pr1_LlucVelazquez.Pages
{
    public class AddEnergyIndicatorModel : PageModel
    {
        [BindProperty]
        public EnergyIndicator NewEnergyIndicator { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string filePath = @"ModelData\indicadors_energetics_cat.json";
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using t4_pr1_LlucVelazquez.Model;
using System.Diagnostics;
using System.Text.Json;
using System;

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
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/
            string filePath = @"ModelData\indicadors_energetics_cat.json";
            var energyIndicator = new EnergyIndicator
            {
                Data = NewEnergyIndicator.Data, PBEE_Hidroelectr = 0, PBEE_Carbo = 0, PBEE_GasNat = 0, PBEE_Fuel_Oil = 0, PBEE_CiclComb = 0, PBEE_Nuclear = 0, 
                    CDEEBC_ProdBruta = 0, CDEEBC_ConsumAux = 0, CDEEBC_ProdNeta = NewEnergyIndicator.CDEEBC_ProdNeta, CDEEBC_ConsumBomb = 0, 
                    CDEEBC_ProdDisp = NewEnergyIndicator.CDEEBC_ProdDisp, CDEEBC_TotVendesXarxaCentral = 0, CDEEBC_SaldoIntercanviElectr = 0, 
                    CDEEBC_DemandaElectr = NewEnergyIndicator.CDEEBC_DemandaElectr, CDEEBC_TotalEBCMercatRegulat = "0.0%", CDEEBC_TotalEBCMercatLliure = "0.0%", 
                    FEE_Industria = 0, FEE_Terciari = 0, FEE_Domestic = 0, FEE_Primari = 0, FEE_Energetic = 0, FEEI_ConsObrPub = 0, FEEI_SiderFoneria = 0, FEEI_Metalurgia = 0, 
                    FEEI_IndusVidre = 0, FEEI_CimentsCalGuix = 0, FEEI_AltresMatConstr = 0, FEEI_QuimPetroquim = 0, FEEI_ConstrMedTrans = 0, FEEI_RestaTransforMetal = 0, 
                    FEEI_AlimBegudaTabac = 0, FEEI_TextilConfecCuirCalçat = 0, FEEI_PastaPaperCartro = 0, FEEI_AltresIndus = 0, DGGN_PuntFrontEnagas = 0, DGGN_DistrAlimGNL = 0, 
                    DGGN_ConsumGNCentrTerm = 0, CCAC_GasolinaAuto = NewEnergyIndicator.CCAC_GasolinaAuto, CCAC_GasoilA = 0
            };
            List<EnergyIndicator> existingEnergyIndicators;
            string jsonStringFile = System.IO.File.ReadAllText(filePath);
            if (!String.IsNullOrEmpty(jsonStringFile))
			{
				existingEnergyIndicators = JsonSerializer.Deserialize<List<EnergyIndicator>>(jsonStringFile);
				
			}else
			{
				existingEnergyIndicators = new List<EnergyIndicator>();
			}
			existingEnergyIndicators.Add(energyIndicator);
			string jsonString = JsonSerializer.Serialize(existingEnergyIndicators);
			System.IO.File.WriteAllText(filePath, jsonString);

            return RedirectToPage("EnergyIndicators");
        }
    }
}

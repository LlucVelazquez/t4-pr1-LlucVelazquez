using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FileWorking = System.IO;
using t4_pr1_LlucVelazquez.Model;
using System.Globalization;
using CsvHelper;
using System.Diagnostics;

namespace t4_pr1_LlucVelazquez.Pages
{
    public class EnergyIndicatorsModel : PageModel
    {
        public string FileErrorMessage;
        public List<EnergyIndicator> EnergyIndicators { get; set; } = new();
        public List<EnergyIndicator> NetProductionAbove3000 => EnergyIndicators.Where(i => i.CDEEBC_ProdNeta > 3000).OrderBy(i => i.CDEEBC_ProdNeta).ToList();
        public List<EnergyIndicator> GasConsumMore100 => EnergyIndicators.Where(i => i.CCAC_GasolinaAuto > 100).OrderByDescending(i => i.CCAC_GasolinaAuto).ToList();
        public List<(int any, decimal mitjanaProduccioNeta)> ProductionAverageForYear => EnergyIndicators.GroupBy(i => i.Data.Year)
                     .Select(g => (any: g.Key, mitjanaProduccioNeta: g.Average(i => i.CDEEBC_ProdNeta))).OrderBy(r => r.any).ToList();
        public void OnGet()
        {
            string CsvFilePath = @"ModelData\indicadors_energetics_cat.csv";
            if (FileWorking.File.Exists(CsvFilePath))
            {
                using var reader = new StreamReader(CsvFilePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                EnergyIndicators = csv.GetRecords<EnergyIndicator>().ToList();
            }
            else
            {
                FileErrorMessage = "Error de carrega de dades";
            }

            /*string[] lines = FileWorking.File.ReadAllLines(CsvFilePath);
            foreach (string line in lines)
            {
                line.Skip(1);
                string[] parts = line.Split(',');
                if (parts.Length == 40)
                {
                    EnergyIndicator energyIndicator = new EnergyIndicator();
                    energyIndicator.Data = DateTime.Parse(parts[0]);
                    energyIndicator.PBEE_Hidroelectr = decimal.Parse(parts[1]);
                    energyIndicator.PBEE_Carbo = decimal.Parse(parts[2]);
                    energyIndicator.PBEE_GasNat = decimal.Parse(parts[3]);
                    energyIndicator.PBEE_Fuel_Oil = decimal.Parse(parts[4]);
                    energyIndicator.PBEE_CiclComb = decimal.Parse(parts[5]);
                    energyIndicator.PBEE_Nuclear = decimal.Parse(parts[6]);
                    energyIndicator.CDEEBC_ProdBruta = decimal.Parse(parts[7]);
                    energyIndicator.CDEEBC_ConsumAux = decimal.Parse(parts[8]);
                    energyIndicator.CDEEBC_ProdNeta = decimal.Parse(parts[9]);
                    energyIndicator.CDEEBC_ConsumBomb = decimal.Parse(parts[10]);
                    energyIndicator.CDEEBC_ProdDisp = decimal.Parse(parts[11]);
                    energyIndicator.CDEEBC_TotVendesXarxaCentral = decimal.Parse(parts[12]);
                    energyIndicator.CDEEBC_SaldoIntercanviElectr = decimal.Parse(parts[13]);
                    energyIndicator.CDEEBC_DemandaElectr = decimal.Parse(parts[14]);
                    energyIndicator.CDEEBC_TotalEBCMercatRegulat = parts[15];
                    energyIndicator.CDEEBC_TotalEBCMercatLliure = parts[16];
                    energyIndicator.FEE_Industria = decimal.Parse(parts[17]);
                    energyIndicator.FEE_Terciari = decimal.Parse(parts[18]);
                    energyIndicator.FEE_Domestic = decimal.Parse(parts[19]);
                    energyIndicator.FEE_Primari = decimal.Parse(parts[20]);
                    energyIndicator.FEE_Energetic = decimal.Parse(parts[21]);
                    energyIndicator.FEEI_ConsObrPub = decimal.Parse(parts[22]);
                    energyIndicator.FEEI_SiderFoneria = decimal.Parse(parts[23]);
                    energyIndicator.FEEI_Metalurgia = decimal.Parse(parts[24]);
                    energyIndicator.FEEI_IndusVidre = decimal.Parse(parts[25]);
                    energyIndicator.FEEI_CimentsCalGuix = decimal.Parse(parts[26]);
                    energyIndicator.FEEI_AltresMatConstr = decimal.Parse(parts[27]);
                    energyIndicator.FEEI_QuimPetroquim = decimal.Parse(parts[28]);
                    energyIndicator.FEEI_ConstrMedTrans = decimal.Parse(parts[29]);
                    energyIndicator.FEEI_RestaTransforMetal = decimal.Parse(parts[30]);
                    energyIndicator.FEEI_AlimBegudaTabac = decimal.Parse(parts[31]);
                    energyIndicator.FEEI_TextilConfecCuirCalçat = decimal.Parse(parts[32]);
                    energyIndicator.FEEI_PastaPaperCartro = decimal.Parse(parts[33]);
                    energyIndicator.FEEI_AltresIndus = decimal.Parse(parts[34]);
                    energyIndicator.DGGN_PuntFrontEnagas = decimal.Parse(parts[35]);
                    energyIndicator.DGGN_DistrAlimGNL = decimal.Parse(parts[36]);
                    energyIndicator.DGGN_ConsumGNCentrTerm = decimal.Parse(parts[37]);
                    energyIndicator.CCAC_GasolinaAuto = decimal.Parse(parts[38]);
                    energyIndicator.CCAC_GasoilA = decimal.Parse(parts[39], CultureInfo.InvariantCulture);
                    NetProductionAbove3000.Add(energyIndicator);
                }
            }*/
        }
    }
}

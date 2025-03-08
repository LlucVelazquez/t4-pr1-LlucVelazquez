namespace t4_pr1_LlucVelazquez.Model
{
    public class EnergyIndicator
    {
        public DateTime Data { get; set; }
        public decimal PBEE_Hidroelectr { get; set; }
        public decimal PBEE_Carbo { get; set; }
        public decimal PBEE_GasNat { get; set; }
        public decimal PBEE_Fuel_Oil { get; set; }
        public decimal PBEE_CiclComb { get; set; }
        public decimal PBEE_Nuclear { get; set; }
        public decimal CDEEBC_ProdBruta { get; set; }
        public decimal CDEEBC_ConsumAux { get; set; }
        public decimal CDEEBC_ProdNeta { get; set; }
        public decimal CDEEBC_ConsumBomb { get; set; }
        public decimal CDEEBC_ProdDisp { get; set; }
        public decimal CDEEBC_TotVendesXarxaCentral { get; set; }
        public decimal CDEEBC_SaldoIntercanviElectr { get; set; }
        public decimal CDEEBC_DemandaElectr { get; set; }
        public string CDEEBC_TotalEBCMercatRegulat { get; set; }
        public string CDEEBC_TotalEBCMercatLliure { get; set; }
        public decimal FEE_Industria { get; set; }
        public decimal FEE_Terciari { get; set; }
        public decimal FEE_Domestic { get; set; }
        public decimal FEE_Primari { get; set; }
        public decimal FEE_Energetic { get; set; }
        public decimal FEEI_ConsObrPub { get; set; }
        public decimal FEEI_SiderFoneria { get; set; }
        public decimal FEEI_Metalurgia { get; set; }
        public decimal FEEI_IndusVidre { get; set; }
        public decimal FEEI_CimentsCalGuix { get; set; }
        public decimal FEEI_AltresMatConstr { get; set; }
        public decimal FEEI_QuimPetroquim { get; set; }
        public decimal FEEI_ConstrMedTrans { get; set; }
        public decimal FEEI_RestaTransforMetal { get; set; }
        public decimal FEEI_AlimBegudaTabac { get; set; }
        public decimal FEEI_TextilConfecCuirCalçat { get; set; }
        public decimal FEEI_PastaPaperCartro { get; set; }
        public decimal FEEI_AltresIndus { get; set; }
        public decimal DGGN_PuntFrontEnagas { get; set; }
        public decimal DGGN_DistrAlimGNL { get; set; }
        public decimal DGGN_ConsumGNCentrTerm { get; set; }
        public decimal CCAC_GasolinaAuto { get; set; }
        public decimal CCAC_GasoilA { get; set; }

    }
}
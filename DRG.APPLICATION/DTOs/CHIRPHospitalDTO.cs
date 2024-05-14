namespace DRG.Application.DTOs
{
    public class CHIRPHospitalDTO
    {
        public int Id { get; set; }

        public required string TIN { get; set; }
        public required string SDA { get; set; }
        public required string CHIRPCLASS { get; set; }
        public required decimal DHPContractRateIP { get; set; }
        public required decimal DHPContractRateIPBH { get; set; }
        public required decimal DHPContractRateOP { get; set; }
        public required decimal UHRIPIP { get; set; }
        public required decimal UHRIPOP { get; set; }
        public required decimal ACIAOP { get; set; }
        public required decimal ACIAIP { get; set; }
        public required decimal TotalCHIRIP { get; set; }
        public required decimal TotalCHIRPOP { get; set; }

        public string? NPI { get; set; }
        public HospitalDTO? Hospital { get; set; }
    }
}

namespace DRG.Application.DTOs
{
    public class CHIRPHospitalDTO
    {
        public required string TIN { get; set; }
        public required string SDA { get; set; }
        public required string CHIRPCLASS { get; set; }
        public required decimal IP { get; set; }
        public required decimal OP { get; set; }
        public required decimal Total { get; set; }

        public string? NPI { get; set; }
        public HospitalDTO? Hospital { get; set; }
    }
}

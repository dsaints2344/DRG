namespace DRG.Application.DTOs
{
    public class HospitalRateDTO
    {
        
        public required string NPI { get; set; }
        public required int Month { get; set; }
        public required int Year { get; set; }
        public required string NPIMonthYear { get; set; }
        public required decimal IPRate { get; set; }
        public required string ProviderName { get; set; }
        public required string SDA { get; set; }
        public required string DeliverySDA { get; set; }
        public required string PPRPPC { get; set; }
        public required string Contract { get; set; }
        public required decimal PercentageThreshold { get; set; }
        public required DateTime HHSCPublishDate { get; set; }
        public decimal? CHIRPRate { get; set; }

        public bool CHIRP { get; set; } = false;

        public string? HospitalNPI { get; set; }
        public HospitalDTO? Hospital { get; set; }
    }
}

using DRG.Domain;

namespace DRG.Application.DTOs
{
    public class HospitalDTO
    {
        public int Id { get; set; }

        public required string HospitalNPI { get; set; }

        public required string HospitalName { get; set; }
        public required string HospitalPhysicalCity { get; set; }
        public required string HospitalPhysicalStreetAddress { get; set; }
        public required string HospitalClass { get; set; }

        public string? TIN { get; set; }
        public CHIRPHospitalDTO? CHIRPHospital { get; set; }

        public ICollection<HospitalRateDTO>? HospitalRates { get; set; }
    }
}



using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DRG.Domain
{
    public class HospitalRate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        public required string NPI { get; set; }
        public required int Month { get; set; }
        public required int Year { get; set; }
        public required string NPIMonthYear { get; set; }
        public required decimal IPRate { get; set; }
        public required string  ProviderName { get; set; }
        public required string SDA { get; set; }
        public required string DeliverySDA { get; set;}
        public required string PPRPPC { get; set; }
        public required string Contract { get; set; }
        public required decimal PercentageThreshold { get; set; }
        public required DateTime HHSCPublishDate { get; set; }
        public decimal? CHIRPRate { get; set; }

        public bool CHIRP { get; set; } = false;

        [ForeignKey("Hospital")]
        public string? HospitalNPI { get; set; }
        public Hospital? Hospital {  get; set; }

    }
}

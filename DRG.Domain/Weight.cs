using System.ComponentModel.DataAnnotations;

namespace DRG.Domain
{
    public class Weight
    {
        public int Id { get; set; }

        [Key]
        public required string APRDRG { get; set; }  // APR DRG code
        public int SOIScore { get; set; } // Severity of illness score
        public required string CombinedSOI { get; set; }  // APR DRG-SOI
        public required string Description { get; set; }  // DRG Description
        public decimal? V36RelativeWeight { get; set; }  
        public decimal? V38RelativeWeight { get; set; }  
        public double? MLOS { get; set; } // Mean Length of stay
        public int? DayOutlierThreshold { get; set; }
    }
}

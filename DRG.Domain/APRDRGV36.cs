using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRG.Domain
{
    public class APRDRGV36
    {
        public int Id { get; set; }

        [Key]
        public required string APRDRG { get; set; }  // APR DRG code
        public int SOIScore { get; set; } // Severity of illness score
        public required string CombinedSOI { get; set; }  // APR DRG-SOI
        public required string Description { get; set; }  // DRG Description
        public decimal? V36RelativeWeight { get; set; }
        public double? MLOS { get; set; } // Mean Length of stay
        public int? DayOutlierThreshold { get; set; }
    }
}

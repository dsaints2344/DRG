using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRG.Domain
{
    public class CHIRPHospital
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
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
        public required decimal Total { get; set; }

       [ForeignKey("Hospital")]
       public string? NPI { get; set; }
       public Hospital? Hospital { get; set; } 
    }
}

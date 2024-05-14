using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public required decimal ACIAOP { get; set; }
        public required decimal IP { get; set; }
        public required decimal OP { get; set; }
        public required decimal Total { get; set; }

       [ForeignKey("Hospital")]
       public string? NPI { get; set; }
       public Hospital? Hospital { get; set; } 
    }
}

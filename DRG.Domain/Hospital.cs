using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRG.Domain
{
    public class Hospital
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        public required string HospitalNPI { get; set; }

        public required string HospitalName { get; set; }
        public required string HospitalPhysicalCity { get; set; }
        public required string HospitalPhysicalStreetAddress { get; set; }
        public required string HospitalClass { get; set; }

        [ForeignKey("CHIRPHospital")]
        public string? TIN { get; set; }
        public CHIRPHospital? CHIRPHospital { get; set; }

        public ICollection<HospitalRate>? HospitalRates { get; set;}


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RealEstateAPI.Domain
{
    public class GNAFLocalityDetails
    {

        [Key]
        public string LocalityPID { get; set; }
        public string LocalityName { get; set; }
        [Column(TypeName = "decimal(9, 6)")]
        public decimal Longitude { get; set; }
        [Column(TypeName = "decimal(8, 6)")]
        public decimal Latitude { get; set; }
        public int PostCode { get; set; }
    }
}

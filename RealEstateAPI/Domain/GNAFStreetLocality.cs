using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RealEstateAPI.Domain
{
    public class GNAFStreetLocality
    {
        [Key]
        public string StreetLocalityPid { get; set; }
        public string Name { get; set; }
        public string StreetType { get; set; }
        public string Suffix { get; set;}
        public string LocalityPID { get; set; }
        [Column(TypeName = "decimal(9, 6)")]
        public decimal Longitude { get; set; }
        [Column(TypeName = "decimal(8, 6)")]
        public decimal Latitude { get; set; }
    }
}

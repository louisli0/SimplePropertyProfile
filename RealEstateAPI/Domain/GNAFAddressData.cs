using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RealEstateAPI.Domain
{
    public class GNAFAddressData
    {
        [Key]
        public string AddressDetailId { get; set; }
        public string LocalityPID { get; set; }
        public string LotPrefix { get; set; }
        public string LotNumber { get; set; }
        public string LotSuffix { get; set; }
        public string FlatType { get; set; }
        public string FlatNumberPrefix { get; set; }
        public int? FlatNumber { get; set; }
        public string FlatNumberSuffix { get; set; }
        public string LevelType { get; set; }
        public string LevelNumberPrefix { get; set; }
        public int? LevelNumber { get; set; }
        public string LevelNumberSuffix { get; set; }
        public string NumberFirstPrefix { get; set; }
        public int? NumberFirst { get; set; }
        public string NumberFirstSuffix { get; set; }
        public string NumberLastPrefix { get; set; }
        public int? NumberLast { get; set; }
        public string NumberLastSuffix { get; set; }

        public int? PostCode { get; set; }
        public string StreetLocalityPID { get; set; }
        [Column(TypeName = "decimal(9, 6)")]
        public decimal Longitude { get; set; }
        [Column(TypeName = "decimal(8, 6)")]
        public decimal Latitude { get; set; }

    }
}

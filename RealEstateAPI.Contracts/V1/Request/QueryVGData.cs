using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.V1.Request
{
    public class QueryVGData
    {
        public int DistrictCode { get; set; }
        public string UnitNumber { get; set; }
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string Locality { get; set; }
        public string PostCode { get; set; }
    }
}

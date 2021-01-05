
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.V1.Response
{
    public class GNAFStreetLocalityResponse
    {
        public string Name { get; set; }
        public string Locality { get; set; }
        public int PostCode { get; set; }
    }
}

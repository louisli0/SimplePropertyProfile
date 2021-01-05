﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.V1.Response
{
    public class VGDataResponse
    {
        public string DealingNumber { get; set; }
        public int DistrictCode { get; set; }
        public string PropertyId { get; set; }
        public string UnitNumber { get; set; }
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string Locality { get; set; }
        public string PostCode { get; set; }
        public string Area { get; set; }
        public string AreaType { get; set; }
        public DateTime SettlementData { get; set; }
        public string price { get; set; }
        public string NatureOfProperty { get; set; }
        public string Purpose { get; set; }
        public string Strata { get; set; }
    }
}

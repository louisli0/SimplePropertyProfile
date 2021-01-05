using Contracts.V1.Request;
using Contracts.V1.Response;
using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAPI.Controllers.V1
{
    public class GNAFController : Controller
    {
        private readonly IGNAFService _service;
        public GNAFController(IGNAFService service)
        {
            _service = service;
        }

        //Query Locality Autocoimplete
        [HttpGet(ApiRoutes.Query.QueryLocality)]
        public async Task<IActionResult> QueryLocalitySearch([FromQuery]QueryVGData data)
        {
            IEnumerable<GNAFLocalityResponse> results = await _service.QueryLocality(data);
            return Ok(results);
        }

        //Query Street Locaclity Autocomplete
        [HttpGet(ApiRoutes.Query.QueryStreet)]
 
        public async Task<IActionResult> QueryStreetLocality([FromQuery] QueryVGData data)
        {
            IEnumerable<dynamic> result = await _service.QueryStreetLocality(data);

            return Ok(result);
        }

        //Query Postcode autocomplete
        [HttpGet(ApiRoutes.Query.QueryPostcode)]

        public async Task<IActionResult> QueryPostCode([FromQuery] QueryVGData data)
        {
            IEnumerable<dynamic> results = await _service.QueryPostCode(data);
            return Ok(results);
        }

    }
}

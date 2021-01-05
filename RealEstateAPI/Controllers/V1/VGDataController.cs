using Contracts.V1.Request;
using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAPI.Controllers.V1
{
    [ApiController]
    public class VGDataController: Controller
    {

        private readonly IVGDataService _dataService;
        public VGDataController(IVGDataService vGDataService)
        {
            _dataService = vGDataService;
        }


        [HttpGet(ApiRoutes.VGData.QueryProperty)]
        public async Task<IActionResult> QueryProperty([FromQuery] QueryVGData data)
        {
            var results = await  _dataService.QueryProperty(data);
            return Ok(results);
        }

        [HttpGet(ApiRoutes.VGData.QueryLocality)]
        public async Task<IActionResult> QueryLocality([FromQuery] QueryVGData data)
        {
            var results = await _dataService.QueryLocality(data);

            return Ok(results);
        }

        [HttpGet(ApiRoutes.VGData.QueryStrata)]
        public async Task<IActionResult> QueryStrata([FromQuery] QueryVGData data)
        {
            var results = await _dataService.QueryStrata(data);
            return Ok(results);
        }


    }
}

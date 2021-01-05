using Contracts.V1.Request;
using RealEstateAPI.Data;
using RealEstateAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contracts.V1.Response;
using Microsoft.Extensions.Logging;

namespace RealEstateAPI.Services
{
    public class GNAFService : IGNAFService
    {
        private readonly GNAFContext _gnafContext;
        private readonly ILogger<GNAFService> _logger;
        public GNAFService(GNAFContext gnafContext, ILogger<GNAFService> logger)
        {
            _gnafContext = gnafContext;
            _logger = logger;
        }
        // Autocomplete search queries
        public async Task<IEnumerable<GNAFLocalityResponse>> QueryLocality(QueryVGData data)
        {
            return await _gnafContext.GNAF_LocalityDetails
                .Where(x => x.LocalityName.Contains(data.Locality))
                .Select(x => new GNAFLocalityResponse
                {
                    Name = x.LocalityName,
                    PostCode = x.PostCode
                }).Take(5).ToListAsync();
        }

        public async Task<IEnumerable<GNAFStreetLocalityResponse>> QueryStreetLocality(QueryVGData data)
        {
            return await _gnafContext.GNAF_StreetLocalityDetails
                .Join(_gnafContext.GNAF_LocalityDetails,
                street => street.LocalityPID,
                locality => locality.LocalityPID,
                (street, locality) => new GNAFStreetLocalityResponse
                {
                    Name = street.Name + " " + street.StreetType,
                    Locality = locality.LocalityName,
                    PostCode = locality.PostCode
                })
                .Where(x => 
                    x.Name.Contains(data.StreetName)
                && x.Locality.Equals(data.Locality)
                ).Take(5)
                .ToListAsync();

        }

        public async Task<IEnumerable<GNAFLocalityResponse>> QueryPostCode(QueryVGData data)
        {
            try
            {
                int.TryParse(data.PostCode, out int parsedPostCode);

                return await _gnafContext.GNAF_LocalityDetails
                    .Where(x => x.PostCode == parsedPostCode)
                    .Select(x => new GNAFLocalityResponse
                    {
                        Name = x.LocalityName,
                        PostCode = x.PostCode
                    })
                    .Take(5)
                    .ToListAsync();
            }
            catch(Exception e) {
                Console.WriteLine($"Error: { e.Message}");
                return null;
            }

        }

        public async Task<IEnumerable<GNAFAddressData>> QueryProperty(QueryVGData data)
        {
            return await _gnafContext.GNAF_AddressData
                .Where(x => x.NumberFirst.Equals(data.HouseNumber) && x.PostCode.Equals(x.PostCode))
                .Select(x => x)
                .Take(5)
                .ToListAsync();
        }
    }
}

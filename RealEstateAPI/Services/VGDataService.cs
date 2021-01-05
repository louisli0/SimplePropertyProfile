using Contracts.V1.Request;
using Contracts.V1.Response;
using RealEstateAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RealEstateAPI.Services
{
    public class VGDataService : IVGDataService
    {
        private readonly DataContext _dataContext;
        public VGDataService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<dynamic>> QueryDistrictMostSold(QueryVGData data)
        {
            IEnumerable<dynamic> results = await _dataContext.NSWVGDatas.Select(x => x).ToListAsync();
            return results;
        }

        public Task<IEnumerable<NSWVGData>> QueryHighestSalePriceByDate()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NSWVGData>> QueryProperty(QueryVGData data)
        {

            IEnumerable<NSWVGData> results =
            await _dataContext.NSWVGDatas
            .Where(
                x => 
                    x.HouseNumber.Contains(data.HouseNumber)
                    && x.StreetName.Contains(data.StreetName)
                    && x.PostCode.Contains(data.PostCode)
                    && x.Purpose.Equals(
                        "RESIDENCE")
                )
            .Select(x => x)
            .ToListAsync();

            return results;
        }

        public async Task<IEnumerable<NSWVGData>> QueryLocality(QueryVGData data)
        {
            IEnumerable<NSWVGData> results =
            await _dataContext.NSWVGDatas
            .Where(
                x =>
                    x.Locality.Equals(data.Locality)
                )
            .Select(x => x)
            .Take(10)
            .ToListAsync();

            return results;
        }

        public async Task<IEnumerable<NSWVGData>> QueryStrata(QueryVGData data)
        {
            IEnumerable<NSWVGData> results =
                await _dataContext.NSWVGDatas
                .Where(x =>
                    x.StreetName.Equals(data.StreetName)
                    && x.Locality.Equals(data.Locality)
                    && x.Strata != null
                    && x.Purpose.Equals("RESIDENCE")
                )
                .Take(10)
                .Select(x => x)
                .ToListAsync();

            return results;
        }
    }
}

using Contracts.V1.Request;
using RealEstateAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAPI.Services
{
    public interface IVGDataService
    {
        Task<IEnumerable<NSWVGData>> QueryProperty(QueryVGData data);
        Task<IEnumerable<NSWVGData>> QueryLocality(QueryVGData data);
        Task<IEnumerable<NSWVGData>> QueryHighestSalePriceByDate();
        Task<IEnumerable<dynamic>> QueryDistrictMostSold(QueryVGData data);
        Task<IEnumerable<NSWVGData>> QueryStrata(QueryVGData data);

    }
}
using Contracts.V1.Request;
using Contracts.V1.Response;
using RealEstateAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAPI.Services
{
    public interface IGNAFService
    {
        Task<IEnumerable<GNAFLocalityResponse>> QueryLocality(QueryVGData data);
        Task<IEnumerable<GNAFLocalityResponse>> QueryPostCode(QueryVGData data);
        Task<IEnumerable<GNAFAddressData>> QueryProperty(QueryVGData data);
        Task<IEnumerable<GNAFStreetLocalityResponse>> QueryStreetLocality(QueryVGData data);
    }
}
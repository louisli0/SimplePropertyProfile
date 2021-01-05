using System;
using Microsoft.AspNetCore.WebUtilities;
public class UriService : IUriService
{
    public readonly string _baseUri;
    public UriService(string baseUri)
    {
        _baseUri = baseUri;
    }

    //public Uri GetListingUri(string listingId)
    //{
    //    return new Uri(_baseUri + ApiRoutes.Listing.Get.Replace("{listingId}", listingId));
    //}

    public Uri GetListingPagination(PaginationQuery pagination = null)
    {
        if(pagination == null)
        {
            return new Uri(_baseUri);
        }
        
        var paginationUri = QueryHelpers.AddQueryString(_baseUri, "PageNumber", pagination.PageNumber.ToString());
        paginationUri = QueryHelpers.AddQueryString(paginationUri, "PageSize", pagination.PageSize.ToString());
        return new Uri(paginationUri);
    }
}
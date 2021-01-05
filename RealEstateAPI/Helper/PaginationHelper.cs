using System;
using System.Collections.Generic;
using System.Linq;
public class PaginationHelper
{
    public static PaginationResponse<T> CreatePaginationResponse<T>(IUriService uriService, PaginationFilter pagination, List<T> response, int totalEntries)
    {
        // Compute Pages
        var nextPage = pagination.PageNumber >= 1 ?
        uriService.GetListingPagination(new PaginationQuery(pagination.PageNumber + 1, pagination.PageSize)).ToString() : null;
        
        var prevPage = pagination.PageSize -1 >= 1 ?
        uriService.GetListingPagination(new PaginationQuery(pagination.PageNumber - 1, pagination.PageSize)).ToString() : null;
        

        double totalPages = ((totalEntries) / pagination.PageSize);
        totalPages = Math.Floor(totalPages);
        return new PaginationResponse<T>
        {
            Data = response,
            PageNumber = pagination.PageNumber >= 1 ? pagination.PageNumber : (int?)null,
            PageSize = pagination.PageSize >= 1? pagination.PageSize : (int?)null,
            NextPage = response.Any() ? nextPage : null,
            PreviousPage = response.Any() ? prevPage : null,
            TotalPages = (int?)totalPages
        };
    }
}
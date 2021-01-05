using System;

public interface IUriService
{
    Uri GetListingPagination(PaginationQuery pagination = null);
}
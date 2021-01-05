using System.Collections.Generic;
public class PaginationResponse<T>
{
    private List<object> listings;
    private List<dynamic> properties;
    public IEnumerable<T> Data { get; set; }
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public int? TotalPages { get; set;}
    public string NextPage { get; set; }
    public string PreviousPage { get; set; }
    

    public PaginationResponse() 
    {}
    public PaginationResponse(IEnumerable<T> data) 
    {
        Data = data;
    }
    public PaginationResponse(List<object> data)
    {
        this.listings = data;
    }

    //public PaginationResponse(List<dynamic> data)
    //{
    //    this.properties = data;
    //}
}
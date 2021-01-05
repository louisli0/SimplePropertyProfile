public class PaginationFilter
{
    public string Number { get; set; }
    public string Suburb { get; set; }
    public string Street { get; set; } 
    public string State { get; set; }
    public string PostCode { get; set;}
    public string MinBedCount { get; set;}
    public string MaxBedCount{ get; set;}
    public string MinBathCount { get; set;}
    public string MaxBathCount { get; set; }
    public string MinParkingCount { get; set; }
    public string MaxParkingCount { get; set; }
    public string MinSize{ get; set; }
    public string MaxSize { get; set; }
    public int PageNumber { get; set;}
    public int PageSize {get; set;}
}
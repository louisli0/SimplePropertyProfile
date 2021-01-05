public class PaginationQuery
{
    public string MinSize{ get; set; }
    public string MaxSize { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public PaginationQuery()
    {
        PageNumber = 1;
        PageSize = 100;
    }
    public PaginationQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
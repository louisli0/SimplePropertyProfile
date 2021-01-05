using AutoMapper;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        CreateMap<PaginationQuery, PaginationFilter>();
        //CreateMap<UpdatePropertyRequest, Property>();
       // CreateMap<UpdateRentalListingRequest, Listing>();
    }
}
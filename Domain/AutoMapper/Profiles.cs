using AutoMapper;
using Domain.Entities.Mongo;
using Domain.Models.Traveler;

namespace Domain.AutoMapper;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<TravelerRequestModel, TravelEntity>(MemberList.Source);
    }
}

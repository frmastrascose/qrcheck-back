using AutoMapper;
using Domain.Entities.Mongo;
using Domain.Models.Test;

namespace Domain.AutoMapper;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<UserRequestModel, UserEntity>()
            .ReverseMap();
    }
}

using Domain.Entities.Mongo;
using Domain.Models.Test;
using System.Collections;

namespace Domain.Contracts.Services
{
    public interface ITravelService
    {
        Task<TravelResponseModel> Create(TravelRequestModel travelRequestModel);

        Task<IEnumerable<TravelEntity>> GetTravel();
    }
}

using Domain.Entities.Mongo;
using Domain.Models.Test;
using System.Collections;

namespace Domain.Contracts.Services
{
    public interface ITravelService
    {
        Task<TravelRequestModel> Create(TravelRequestModel travelRequestModel);

        Task<IEnumerable<TravelEntity>> GetTravel();
    }
}

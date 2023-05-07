using Domain.Entities.Mongo;
using Domain.Models.Traveler;

namespace Domain.Contracts.Services
{
    public interface ITravelerService
    {
        Task<TravelerResponseModel> Create(TravelerRequestModel travelRequestModel);
        
        Task<IEnumerable<TravelerEntity>> GetAll();

        Task<TravelerEntity> GetById(string id);

        Task Update(TravelerEntity travelerEntity, bool sendConfirmation);

    }
}

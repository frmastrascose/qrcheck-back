using Domain.Contracts;
using Domain.Contracts.Services;
using Domain.Entities.Mongo;
using Domain.Models.Test;
using Microsoft.Extensions.Configuration;
using System.Numerics;

namespace Domain.Services
{
    public class TravelService : ITravelService
    {
        private readonly IRepository<TravelEntity> _travelRepository;

        private readonly IConfiguration _configuration;
              
        public TravelService(IRepository<TravelEntity> travelRepository, IConfiguration cofiguration)
        {
            _travelRepository = travelRepository;
            _configuration = cofiguration;

        }
       
        public async Task<TravelResponseModel> Create(TravelRequestModel travelRequestModel)
        {
            var travelEntity = new TravelEntity
            {
                HotelName = travelRequestModel.HotelName,
                CheckIn = travelRequestModel.CheckIn,
                CheckOut = travelRequestModel.CheckOut,
                ReservID = travelRequestModel.ReservID,
                RoomType = travelRequestModel.RoomType,
                CancelData = travelRequestModel.CancelData,
                IsActive = true
            };
            var createdId = await _travelRepository.InsertOneAsync(travelEntity);
            var response = new TravelResponseModel
            {
                Id = createdId.ToString()
            };

            return response;
        }

        public async Task<IEnumerable<TravelEntity>> GetTravel()
        {
            return await _travelRepository.FindAsync(x => x.IsActive);
        }

    }

}

using AutoMapper;
using Domain.Contracts;
using Domain.Contracts.Services;
using Domain.Entities.Mongo;
using Domain.Models.Test;

namespace Domain.Services
{
    public class TravelerService : ITravelerService
    {
        private readonly IRepository<UserEntity> _travelerRepository;
        private readonly IMapper _mapper;

        public TravelerService(IRepository<UserEntity> travelerRepository, IMapper mapper)
        {
            _travelerRepository = travelerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _travelerRepository.FindAsync(x => x.IsActive);
        }

        public async Task<TravelerResponseModel> Create(TravelerRequestModel travelerRequestModel)
        {

            var userEntity = _mapper.Map<UserEntity>(travelerRequestModel);
            userEntity.IsActive = true;

            var createdId = await _travelerRepository.InsertOneAsync(userEntity);
            var response = new TravelerResponseModel
            {
                Id = createdId.ToString()
            };

            return response;
        }
    }
}

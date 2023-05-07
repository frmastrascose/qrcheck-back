using AutoMapper;
using Domain.Contracts;
using Domain.Contracts.Services;
using Domain.Entities.Mongo;
using Domain.Models.Test;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<TravelerEntity> _userRepository;

        public UserService( IRepository<TravelerEntity> testRepository)
        {
            _userRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TravelerEntity>> GetAll()
        {
            return await _userRepository.FindAsync(x => x.IsActive);
        }

        public async Task<UserResponseModel> Create(UserRequestModel userRequestModel)
        {

            var userEntity = new TravelerEntity
            {
                Name = userRequestModel.Name,
                Email = userRequestModel.Email,
                Login = userRequestModel.Login,
                Password = userRequestModel.Password,
                IsActive = true
        };

            var createdId = await _userRepository.InsertOneAsync(userEntity);
            var response = new UserResponseModel
            {
                Id = createdId.ToString()
            };

            return response;
        }
    }
}

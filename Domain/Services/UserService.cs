using Domain.Contracts;
using Domain.Contracts.Services;
using Domain.Entities.Mongo;
using Domain.Models.Test;
using Microsoft.Extensions.Configuration;
using System.Numerics;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<TravelerEntity> _userRepository;

        public UserService( IRepository<TravelerEntity> testRepository)
        {
            _userRepository = testRepository;
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

        public void Update(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }
    }
}

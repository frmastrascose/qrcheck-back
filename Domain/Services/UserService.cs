using AutoMapper;
using Domain.Contracts;
using Domain.Contracts.Services;
using Domain.Entities.Mongo;
using Domain.Models.Test;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> testRepository, IMapper mapper)
        {
            _userRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _userRepository.FindAsync(x => x.IsActive);
        }

        public async Task<UserResponseModel> Create(UserRequestModel userRequestModel)
        {

            var userEntity = _mapper.Map<UserEntity>(userRequestModel);
            userEntity.IsActive = true;

            var createdId = await _userRepository.InsertOneAsync(userEntity);
            var response = new UserResponseModel
            {
                Id = createdId.ToString()
            };

            return response;
        }
    }
}

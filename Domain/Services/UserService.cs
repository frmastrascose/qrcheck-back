﻿using Domain.Contracts;
using Domain.Contracts.Services;
using Domain.Entities.Mongo;
using Domain.Models.Test;
using Microsoft.Extensions.Configuration;
using System.Numerics;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _userRepository;

        private readonly IConfiguration _configuration;

        public UserService( IRepository<UserEntity> testRepository, IConfiguration cofiguration)
        {
            _userRepository = testRepository;
            _configuration = cofiguration;
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _userRepository.FindAsync(x => x.IsActive);
        }

        public async Task<UserResponseModel> Create(UserRequestModel userRequestModel)
        {

            var userEntity = new UserEntity
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
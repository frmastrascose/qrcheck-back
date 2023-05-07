﻿using Domain.Entities.Mongo;
using Domain.Models.Test;
using System.Collections;

namespace Domain.Contracts.Services
{
    public interface IUserService
    {
        Task<UserResponseModel> Create(UserRequestModel userRequestModel);
        
        Task<IEnumerable<TravelerEntity>> GetAll();

        public void Update(UserRequestModel userRequestModel);

    }
}

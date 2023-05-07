﻿using Domain.Entities.Mongo;
using Domain.Models.Test;
using System.Collections;

namespace Domain.Contracts.Services
{
    public interface ITravelerService
    {
        Task<TravelerResponseModel> Create(TravelerRequestModel userRequestModel);
        
        Task<IEnumerable<TravelerEntity>> GetAll();

        public void Update(UserRequestModel userRequestModel);

    }
}
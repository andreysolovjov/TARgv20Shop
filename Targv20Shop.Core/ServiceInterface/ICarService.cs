﻿using System;
using System.Threading.Tasks;
using Targv20Shop.Core.Domain;
using Targv20Shop.Core.Dtos;

namespace Targv20Shop.Core.ServiceInterface
{
    public interface ICarService : IApplicationService
    {
        Task<Car> Delete(Guid id);

        Task<Car> Add(CarDto dto);

        Task<Car> Edit(Guid id);
        Task<Car> Update(CarDto dto);
    }
}
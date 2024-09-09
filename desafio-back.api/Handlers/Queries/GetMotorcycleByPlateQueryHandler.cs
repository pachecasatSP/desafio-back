﻿using desafio_back.api.Models.Queries;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Models.Entities;
using MediatR;

namespace desafio_back.api.Handlers.Queries
{
    public class GetMotorcycleByPlateQueryHandler : IRequestHandler<GetMotorcycleByPlateQuery, Motorcycle> 
    {
        private IMotorcycleService _service;

        public GetMotorcycleByPlateQueryHandler(IMotorcycleService service)
        {
            _service = service;
        }

        public async Task<Motorcycle> Handle(GetMotorcycleByPlateQuery request, CancellationToken cancellationToken)
        {
            return await _service.FirstOrDefaultAsync((x) => x.Placa == request.Placa);

        }
    }
}

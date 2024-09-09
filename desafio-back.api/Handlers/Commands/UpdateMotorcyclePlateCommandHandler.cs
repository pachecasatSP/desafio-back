﻿using AutoMapper;
using desafio_back.domain.Abstractions.Services;
using MediatR;

namespace desafio_back.api.Handlers.Commands
{
    public class UpdateMotorcyclePlateCommandHandler : IRequestHandler<UpdateMotorcyclePlateCommand, bool>
    {
        private IMotorcycleService _service;
        private IMapper _mapper;

        public UpdateMotorcyclePlateCommandHandler(IMotorcycleService service,
                                                     IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateMotorcyclePlateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _service.FirstOrDefaultAsync(x => x.Placa == request.oldPlate);
            if(entity == null)
                return false;

            entity.Placa = request.newPlate;

            await _service.SaveAsync(entity);
            return true;
        }
    }
}

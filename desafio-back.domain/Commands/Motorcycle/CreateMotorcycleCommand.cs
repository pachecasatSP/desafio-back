using desafio_back.domain.Entities.DomainEntities;
using MediatR;

namespace desafio_back.domain.Commands;

public record CreateMotorcycleCommand(string? Identificador, int Ano, string? Modelo, string? Placa) : IRequest<Motorcycle>;

using desafio_back.domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace desafio_back.api.Models.Commands
{
    public record CreateMotorcycleCommand(string? Identificador, int Ano, string? Modelo, string? Placa) : IRequest<Motorcycle>;
}

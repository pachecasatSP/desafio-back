using desafio_back.domain.Entities.DomainEntities;
using MediatR;

namespace desafio_back.domain.Commands
{
    public record CreateDeliveryManCommand(string Identificador, string? Nome, string? Cnpj, DateTime DataNascimento, string? NumeroCnh, string? TipoCnh) : IRequest<DeliveryMan>;
}

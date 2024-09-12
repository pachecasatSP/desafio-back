using desafio_back.domain.Entities.DomainEntities;
using MediatR;

namespace desafio_back.domain.Commands
{
    public class CreateRentalCommand : IRequest<Rental>
    {
        public string? EntregadorId { get; set; }
        public string? MotoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public DateTime DataPrevisaoTermino { get; set; }
        public int Plano { get; set; }
    }
}

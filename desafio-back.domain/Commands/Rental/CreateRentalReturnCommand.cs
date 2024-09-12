using MediatR;

namespace desafio_back.domain.Commands
{
    public record CreateRentalReturnCommand(string Id, DateTime ReturnDate) : IRequest<bool>;
}

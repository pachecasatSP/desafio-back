using MediatR;

namespace desafio_back.domain.Commands;

public record DeleteMotorcycleByIdCommand(string Identificador) : IRequest<bool>;

using MediatR;

namespace desafio_back.domain.Commands;

public record UpdateMotorcyclePlateCommand(string oldPlate, string newPlate) : IRequest<bool>;

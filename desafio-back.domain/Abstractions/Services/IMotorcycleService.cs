using desafio_back.domain.Entities.DomainEntities;

namespace desafio_back.domain.Abstractions.Services
{
    public interface IMotorcycleService : IService<Motorcycle>
    {
        Task<bool> PlateDoesNotExists(string placa);
        Task<bool> IdDoesNotExists(string identificador);
        Task<bool> IdExists(string identificador);

    }
}

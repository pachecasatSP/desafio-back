using desafio_back.domain.Entities.DomainEntities;

namespace desafio_back.domain.Abstractions.Services
{
    public interface IRentalService : IService<Rental>
    {
        Task<decimal> CalculateReturValue(Rental rental, DateTime returnDate);
    }
}

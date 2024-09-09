using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Models.Entities;
using System.Linq.Expressions;

namespace desafio_back.api.Services
{
    public class DeliverymanService : IDeliverymanService
    {
        public Task<bool> DeleteAsync(string identificador)
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryMan> FirstOrDefaultAsync(Expression<Func<DeliveryMan, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DeliveryMan>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryMan> QueryAsync(string identificador, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryMan> SaveAsync(DeliveryMan entity)
        {
            throw new NotImplementedException();
        }
    }
}

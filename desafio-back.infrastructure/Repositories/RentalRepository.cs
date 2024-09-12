using desafio_back.domain.Abstractions.Repositories;
using desafio_back.domain.Entities.DomainEntities;
using desafio_back.infrastructure.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace desafio_back.infrastructure.Repositories
{
    public class RentalRepository : RepositoryBase<Rental>, IRentalRepository
    {
        public RentalRepository(RentalManagementContext context)
            : base(context) { }

        public override Task<Rental> FirstOrDefaultAsync(Expression<Func<Rental, bool>> predicate)
        {
            var query = _context.Rental
                                .Include(x => x.Motorcycle)
                                .Include(x => x.Plan)
                                .Include(x => x.DeliveryMan).FirstOrDefaultAsync(predicate);
            return query!;
        }
    }
}

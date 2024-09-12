using desafio_back.api.Services;
using desafio_back.domain.Abstractions.Repositories;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Entities.DomainEntities;
using System.Linq.Expressions;

namespace desafio_back.domain.Services
{
    public class RentalService : ServiceBase<Rental>, IRentalService
    {
        public RentalService(IRentalRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> CalculateReturValue(Rental rental, DateTime returnDate)
        {
            var plan = rental.Plan;

            decimal penaltyValue = 0;
            decimal totalAmountWithoutPenalties = rental.Plan.Value *
                                                 ((int)returnDate.Subtract(rental.StartDate).TotalDays);

            if (returnDate < rental.ForecastEndDate)
                penaltyValue = CalculateEarlyReturn(rental, returnDate);

            if (returnDate > rental.ForecastEndDate)
                penaltyValue = CalculateLateReturn(rental, returnDate);

            return totalAmountWithoutPenalties + penaltyValue;
        }
        private decimal CalculateLateReturn(Rental rental, DateTime returnDate) =>
            rental.Plan.AdditionalDayValue * ((int)rental.ForecastEndDate.Subtract(returnDate).TotalDays);
        private decimal CalculateEarlyReturn(Rental rental, DateTime returnDate) =>
            (rental.Plan.Value * ((int)rental.ForecastEndDate.Subtract(returnDate).TotalDays)) * rental.Plan.EarlyPenalty;

        public override async Task<Rental> FirstOrDefaultAsync(Expression<Func<Rental, bool>> predicate) =>
            await _repository!.FirstOrDefaultAsync(predicate);
    }
}

using desafio_back.domain.Models.Base;

namespace desafio_back.domain.Entities.DomainEntities;

public class RentalPlan : EntityBase
{
    public string? Name { get; set; }
    public int TermInDays { get; set; }
    public decimal Value { get; set; }
    public decimal EarlyPenalty { get; set; }
    public decimal AdditionalDayValue { get; set; }

    public ICollection<Rental> RentalCollection { get; set; } = [];

    public void AddRental(Rental rental)
    {
        rental.Plan = this;
        RentalCollection.Add(rental);
    }
}

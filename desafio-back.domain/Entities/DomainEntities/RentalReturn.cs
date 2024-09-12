using desafio_back.domain.Models.Base;

namespace desafio_back.domain.Entities.DomainEntities;

public class RentalReturn : EntityBase
{
    public int RentalId { get; set; }

    public Rental Rental { get; set; }

    public DateTime Date { get; set; }

    public decimal Value { get; set; }

}

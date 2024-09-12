using desafio_back.domain.Models.Base;

namespace desafio_back.domain.Entities.DomainEntities;

public class Motorcycle : EntityBase
{
    public int Year { get; set; }
    public string? Model { get; set; }
    public string? Plate { get; set; }

    public ICollection<Rental> RentalCollection { get; set; } = [];
    public void AddRental(Rental rental)
    {
        rental.Motorcycle = this;
        RentalCollection.Add(rental);
    }
}

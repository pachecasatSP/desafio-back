using desafio_back.domain.Models.Base;

namespace desafio_back.domain.Entities.DomainEntities;

public class DeliveryMan : EntityBase
{
    public string? Name { get; set; }
    public string? Cnpj { get; set; }
    public DateTime BirthDate { get; set; }
    public string? CNHNumber { get; set; }
    public string? CNHType { get; set; }
    public string? CNHImage { get; set; }

    public ICollection<Rental>? RentalCollection { get; set; } = [];

    public void AddRental(Rental rental)
    {
        rental.DeliveryMan = this;
        RentalCollection?.Add(rental);
    }
}




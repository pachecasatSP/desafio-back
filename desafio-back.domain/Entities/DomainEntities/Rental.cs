using desafio_back.domain.Models.Base;

namespace desafio_back.domain.Entities.DomainEntities;

public class Rental : EntityBase
{
    public override string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 8);
    public int DeliveryManId { get; set; }
    public int MotorcycleId { get; set; }
    public int PlanId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime ForecastEndDate { get; set; }
    public RentalPlan Plan { get; set; }
    public DeliveryMan DeliveryMan { get; set; }
    public Motorcycle Motorcycle { get; set; }
    public RentalReturn? RentalReturn { get; set; }

    public void CreateReturn(decimal totalamount, DateTime returnDate)
    {
        this.EndDate = returnDate;

        if (RentalReturn is null)
            RentalReturn = new RentalReturn();

        RentalReturn.Rental = this;
        RentalReturn.Value = totalamount;
        RentalReturn.Date = returnDate;
    }
}

using desafio_back.domain.Entities.DomainEntities;

namespace dsafio_back.tests.Mocks.Factories;
public class DeliveryManFactory
{
    public static DeliveryMan CreateValidDeliveryMan() => new DeliveryMan()
    {
        Cnpj = "16055381000146",
        Id = "primeiroEntregador",
        Name = "Primeiro Entregador",
        BirthDate = new DateTime(1982, 1, 23),
        CNHNumber = "12345678",
        CNHType = "A"
    };

    public static DeliveryMan CreateInvalidDeliveryMan() => new DeliveryMan()
    {
        Cnpj = "16055381000146",
        Id = "primeiroEntregador",
        Name = "Primeiro Entregador",
        BirthDate = new DateTime(1982, 1, 23),
        CNHNumber = "12345678",
        CNHType = "C"
    };

}

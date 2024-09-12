using desafio_back.api.Models.Request;

namespace desafio_back.teste.xunit.Mocks.Factories
{
    public class DeliveryManRequestFactory
    {
        public static CreateDeliveryManRequest CreateValid()
        {
            return new CreateDeliveryManRequest("primeiroEntregador",
                                                "Primeiro Entregador",
                                                "16055381000146",
                                                new DateTime(1982, 1, 23),
                                                "12345678", "A");
        }

        public static CreateDeliveryManRequest CreateInvalid()
        {
            return new CreateDeliveryManRequest("primeiroEntregador",
                                                "Primeiro Entregador",
                                                "16055381000146",
                                                new DateTime(1982, 1, 23),
                                                "12345678", "C");
        }
    }
}

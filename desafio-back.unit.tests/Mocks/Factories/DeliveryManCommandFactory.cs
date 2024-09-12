using desafio_back.domain.Commands;

namespace dsafio_back.tests.Mocks.Commands
{
    public class DeliveryManCommandFactory
    {
        public static CreateDeliveryManCommand CreateValidCommand()
        {
            return new CreateDeliveryManCommand("primeiroEntregador",
                                                "Primeiro Entregador",
                                                "16055381000146",
                                                new DateTime(1982, 1, 23),
                                                "12345678", "A");
        }

        public static CreateDeliveryManCommand CreateInvalidCommand()
        {
            return new CreateDeliveryManCommand("primeiroEntregador",
                                                "Primeiro Entregador",
                                                "16055381000146",
                                                new DateTime(1982, 1, 23),
                                                "12345678", "C");
        }

    }
}

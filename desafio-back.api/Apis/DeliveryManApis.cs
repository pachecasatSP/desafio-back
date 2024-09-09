using MassTransit.Mediator;

namespace desafio_back.api.Apis
{
    public static class DeliveryManApis
    {
        public static void DeliveryManEndpoints(this IEndpointRouteBuilder routes)
        {

            routes.MapPost("/entregadores", async (CreateDeliveryManCommandValidator validator, IMediator mediatr, CreateDeliveryManCommand command) =>
            {

            });

        }
    }

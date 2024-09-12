using AutoMapper;
using desafio_back.api.Models.Request;
using desafio_back.api.Models.Results;
using desafio_back.domain.Commands;
using desafio_back.domain.Entities.DomainEntities;
using desafio_back.domain.Entities.Response;
using desafio_back.domain.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace desafio_back.api.Apis
{
    public static class RentalApi
    {
        public static void MapRentalEndpoints(this IEndpointRouteBuilder routes)
        {

            routes.MapPost("/locacao", async (IValidator<CreateRentalRequest> validator, IMapper mapper,
                                            IMediator mediatr, [FromServices] ILogger<Program> logger, CreateRentalRequest request) =>
            {

                var command = mapper.Map<CreateRentalCommand>(request);

                var response = await mediatr.Send(command);

                return response is Rental
                    ? DefaultResults.CreateCreatedResult()
                    : DefaultResults.CreateInvalidResult();

            }).AddFluentValidationFilter();

            routes.MapGet("/locacao/{id}", async (IMediator mediatr, string? id) =>
            {
                var response = await mediatr.Send(new GetRentalByIdQuery(id!));
                return response is GetRentalByIdResponse
                    ? DefaultResults.CreateOkResultResponse(response)
                    : DefaultResults.CreateInvalidResult();

            });

            routes.MapPut("/locacao/{id}/devolucao", async (IValidator<CreateRentalReturnRequest> validator, IMediator mediatr, string id, [FromBody] CreateRentalReturnRequest request) =>
            {
                var response = await mediatr.Send(new CreateRentalReturnCommand(id, request.Data_devolucao));

                return response
                    ? DefaultResults.CreateOkResult("Data de devolução informada com sucesso")
                    : DefaultResults.CreateInvalidResult();

            }).AddFluentValidationFilter();

        }
    }
}
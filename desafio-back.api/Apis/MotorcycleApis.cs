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

namespace desafio_back.api.Apis;
public static class MotorcycleApis
{
    public static void MapMotorcycleEndpoints(this IEndpointRouteBuilder routes)
    {

        routes.MapPost("/motos", async (IValidator<CreateMotorcycleRequest> validator, IMediator mediatr,
                                        IMapper mapper, [FromServices] ILogger<Program> logger, CreateMotorcycleRequest request) =>
        {

            var command = mapper.Map<CreateMotorcycleCommand>(request);

            var response = await mediatr.Send(command);
            return response is Motorcycle
                    ? DefaultResults.CreateCreatedResult()
                    : DefaultResults.CreateInvalidResult();

        }).AddFluentValidationFilter();

        routes.MapGet("/motos", async (IMediator mediatr) =>
        {
            var response = await mediatr.Send(new GetAllMotorcyclesQuery());
            return response.Any()
                ? DefaultResults.CreateOkResultResponse(response.ToList())
                : DefaultResults.CreateNotFoundResult();
        });
        
        routes.MapPut("motos/{id}/placa", async (IValidator<UpdateMotorcyclePlateRequest> validator, IMediator mediatr,
                                                string id, [FromServices] ILogger<Program> logger, [FromBody] UpdateMotorcyclePlateRequest request) =>
        {
            var response = await mediatr.Send(new UpdateMotorcyclePlateCommand(id, request.Placa));
            return response
                ? DefaultResults.CreateOkResult("Placa modificada com sucesso. ")
                : DefaultResults.CreateInvalidResult();
        }).AddFluentValidationFilter();

        routes.MapGet("motos/{id}", async (IMediator mediatr, string? id) =>
        {
            if (id is null)
                return DefaultResults.CreateInvalidResult();

            var response = await mediatr.Send(new GetMotorcycleByIdQuery(id!));
            return response is GetMotorcycleResponse
                 ? DefaultResults.CreateOkResultResponse(response)
                 : DefaultResults.CreateInvalidResult("moto não encontrada.");

        });

        routes.MapDelete("motos/{id}", async (IMediator mediatr, string id) =>
        {
            var response = await mediatr.Send(new DeleteMotorcycleByIdCommand(id));
            return response
                ? DefaultResults.CreateOkResult()
                : DefaultResults.CreateInvalidResult();
        });
    }
}

using AutoMapper;
using desafio_back.api.Models.Request;
using desafio_back.api.Models.Results;
using desafio_back.domain.Commands;
using desafio_back.domain.Entities.DomainEntities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace desafio_back.api.Apis;
public static class DeliveryManApis
{
    public static void MapDeliveryManEndpoints(this IEndpointRouteBuilder routes)
    {

        routes.MapPost("/entregadores", async (IValidator<CreateDeliveryManRequest> validator, IMediator mediatr,
                                              IMapper mapper, [FromServices] ILogger<Program> logger, CreateDeliveryManRequest request) =>
        {

            var command = mapper.Map<CreateDeliveryManCommand>(request);

            var response = await mediatr.Send(command);
            return response is DeliveryMan
                ? DefaultResults.CreateCreatedResult()
                : DefaultResults.CreateInvalidResult();

        }).AddFluentValidationFilter();

        routes.MapPost("/entregadores/{id}/cnh", async (IValidator<SendDriverLicenseForDeliveryManRequest> validator,
                                                        IMediator mediatr, string? id, [FromBody] SendDriverLicenseForDeliveryManRequest request) =>
        {
            var response = await mediatr.Send(new SendDriverLicenseForDeliveryManCommand(id, request.Imagem_cnh));
            return response
                 ? DefaultResults.CreateCreatedResult()
                 : DefaultResults.CreateInvalidResult();
        }).AddFluentValidationFilter();
    }
}
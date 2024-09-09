using desafio_back.api.Handlers.Commands;
using desafio_back.api.Models.Commands;
using desafio_back.api.Models.Queries;
using desafio_back.api.Models.Request;
using desafio_back.domain.Models.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace desafio_back.api.MinimalApis
{
    public static class MotorcycleApis
    {
        public static void MapMotorcycleEndpoints(this IEndpointRouteBuilder routes)
        {

            routes.MapPost("/motos", async (IValidator<CreateMotorcycleCommand> validator, IMediator mediatr, CreateMotorcycleCommand command) =>
            {
                var result = await validator.ValidateAsync(command);
                if (!result.IsValid)
                    return Results.Json(new { Mensagem = "dados inválidos." }, statusCode: 400);

                var response = await mediatr.Send(command);
                if (response is Motorcycle)
                    return Results.Created();
                else
                    return Results.Json(new { Mensagem = "dados inválidos." }, statusCode: 400);
            });

            routes.MapGet("/motos", async (IMediator mediatr) =>
            {
                var response = await mediatr.Send(new GetAllMotorcyclesQuery());
                return Results.Ok(response.ToList());
            });

            routes.MapGet("motos/{id}/placa", async (IMediator mediatr, string id) =>
            {
                var response = await mediatr.Send(new GetMotorcycleByPlateQuery(id));
                if (response == null)
                    return Results.BadRequest();

                return Results.Ok(response);
            });

            routes.MapPut("motos/{id}/placa", async (IValidator<UpdateMotorcyclePlateRequest> validator, IMediator mediatr, string id, [FromBody] UpdateMotorcyclePlateRequest request) =>
            {
                var result = await validator.ValidateAsync(request);
                if(!result.IsValid)
                    return Results.Json(new { Mensagem = "Dados inválidos." }, statusCode: 400);

                var response = await mediatr.Send(new UpdateMotorcyclePlateCommand(id, request.placa));
                if (response)
                    return Results.Ok(new { Mensagem = "Placa modificada com sucesso. " });
                else
                    return Results.Json(new { Mensagem = "Dados inválidos." }, statusCode: 400);
            });

            routes.MapGet("motos/{id}", async (IMediator mediatr, string? id) =>
            {
                if (id is null)
                    return Results.Json(new { Mensagem = "Request mal formada" }, statusCode: 400);

                var response = await mediatr.Send(new GetMotorcycleByIdQuery(id!));
                if (response is null)
                    return Results.Json(new { Mensagem = "Moto não encontrada." }, statusCode: 404);
                else
                    return Results.Ok(response);

            });

            routes.MapDelete("motos/{id}", async (IMediator mediatr, string id) =>
            {
                var response = await mediatr.Send(new DeleteMotorcycleByIdCommand(id));
                if (response)
                    return Results.Ok();
                else
                    return Results.Json(new { Mensagem = "dados inválidos." });
            });
        }
    }
}

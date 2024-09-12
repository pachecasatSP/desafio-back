using desafio_back.domain.Entities.Response;
using desafio_back.domain.Models.Base;

namespace desafio_back.api.Models.Results
{
    public class DefaultResults
    {
        public static IResult CreateCreatedResult() =>
            TypedResults.Created();
        public static IResult CreateInvalidResult() =>
            CreateInvalidResult("dados inválidos.");
        public static IResult CreateInvalidResult(string message) =>
            TypedResults.Json(new { Mensagem = message }, statusCode: 400);
        public static IResult CreateNotFoundResult() =>
            TypedResults.NotFound();
        public static IResult CreateOkResult() =>
            TypedResults.Ok();
        public static IResult CreateOkResultEntity<TEntity>(TEntity entity) where TEntity : EntityBase =>
            TypedResults.Ok(entity);
        public static IResult CreateOkResultResponse<TResponse>(TResponse response) where TResponse : IDomainResponse =>
            TypedResults.Ok(response);
        public static IResult CreateOkResultResponse<TResponse>(List<TResponse> response) where TResponse : IDomainResponse =>
            TypedResults.Ok(response);
        public static IResult CreateOkResultEntity<TEntity>(List<TEntity> entityList) where TEntity : EntityBase =>
            TypedResults.Ok(entityList);
        public static IResult CreateOkResult(string message) =>
            TypedResults.Ok(new { Mensagem = message });


    }
}

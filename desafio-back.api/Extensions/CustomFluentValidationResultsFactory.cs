using desafio_back.api.Models.Results;
using FluentValidation.AspNetCore.Http;
using FluentValidation.Results;

namespace desafio_back.api.Extensions;

public class CustomFluentValidationResultsFactory : IFluentValidationEndpointFilterResultsFactory
{
    private ILogger<CustomFluentValidationResultsFactory> _logger;

    public CustomFluentValidationResultsFactory(ILogger<CustomFluentValidationResultsFactory> logger) =>
        _logger = logger;

    public IResult Create(ValidationResult validationResult)
    {
        _logger.LogInformation("Foram encontrados os seguintes erros de validação:");

        foreach (var error in validationResult.Errors)
            _logger.LogInformation($"- {error.ErrorMessage}");

        return DefaultResults.CreateInvalidResult();
    }
}

using DistributedSystem.Contract.Abstractions.Shared;
using FluentValidation;
using MediatR;

namespace DistributedSystem.Application.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        Error[] errors = _validators
            .Select(validator => validator.Validate(request))
            .SelectMany(validationResult => validationResult.Errors)
            .Where(validationFailure => validationFailure is not null)
            .Select(failure => new Error(
                failure.PropertyName, 
                failure.ErrorMessage))
            .Distinct()
            .ToArray();

        if (errors.Any())
        {
            // Return a validation result, not throwing an exception
            return CreateValidationResult<TResponse>(errors);
        }

        return await next();
    }

    private static TResult CreateValidationResult<TResult>(Error[] errors)
        where TResult : Result
    {
        if (typeof(TResult) == typeof(Result))
        {
            return (ValidationResult.WithErrors(errors) as TResult)!;
        }

        // Read more: https://learn.microsoft.com/en-us/dotnet/api/system.type.makegenerictype?view=net-8.0#system-type-makegenerictype(system-type

        /**
         * 2. Sử dụng phương thức MakeGenericType trên kiểu chung ValidationResult<> và cung cấp cho nó tham số kiểu chung đầu tiên từ TResult. Ví dụ: nếu TResult là MyResponse, thì kiểu mới sẽ là ValidationResult<MyResponse>.
         * 3. Sử dụng phương thức GetMethod trên kiểu mới được tạo để truy xuất phương thức WithErrors
         * 4. Sử dụng phương thức Invoke trên phương thức WithErrors được truy xuất để gọi nó một cách động. Phương thức Invoke được gọi trên null vì phương thức WithErrors là một phương thức tĩnh. Tham số errors được truyền vào phương thức WithErrors dưới dạng đối số
         */
        object validationResult = typeof(ValidationResult<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
            .GetMethod(nameof(ValidationResult.WithErrors)) !
            .Invoke(null, new object?[] { errors }) !;

        return (TResult)validationResult;
    }
}

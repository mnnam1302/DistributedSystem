namespace DistributedSystem.Contract.Abstractions.Shared
{
    public interface IValidationResult
    {
        public static readonly Error ValidationError = new(
            "Error.Validation",
            "The specific result value is invalid.");

        Error[] Errors { get; }
    }
}
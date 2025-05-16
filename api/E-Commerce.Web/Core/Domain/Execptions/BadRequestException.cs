namespace Domain.Execptions;

public sealed class BadRequestException(IEnumerable<string> errors):Exception(string.Join("; ", errors))
{
    public IEnumerable<string> Errors { get; } = errors;
}
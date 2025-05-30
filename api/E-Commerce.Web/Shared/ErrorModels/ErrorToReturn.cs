namespace Shared.ErrorModels;

public class ErrorToReturn
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public IEnumerable<string>? Errors { get; set; }
}
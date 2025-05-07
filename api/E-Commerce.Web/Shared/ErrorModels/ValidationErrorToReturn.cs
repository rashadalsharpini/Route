using System.Net;

namespace Shared.ErrorModels;

public class ValidationErrorToReturn
{
    public int statusCode { get; set; } = (int)HttpStatusCode.BadRequest;
    public string message { get; set; } = "Validation Error";
    public IEnumerable<ValidationError> errors { get; set; } = new List<ValidationError>();
}
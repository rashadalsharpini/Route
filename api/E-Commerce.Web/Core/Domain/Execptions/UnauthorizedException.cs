namespace Domain.Execptions;

public sealed class UnauthorizedException(string message = "invalid email or password") : Exception(message);
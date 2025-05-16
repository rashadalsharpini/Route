namespace Domain.Execptions;

public sealed class UserNotFoundException(string email) : NotFoundException($"User not found with email {email}");
namespace Domain.Execptions;

public sealed class AddressNotFoundException(string email):NotFoundException($"{email} doesn't have an address")
{
    
}
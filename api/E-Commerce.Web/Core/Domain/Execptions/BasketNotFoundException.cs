namespace Domain.Execptions;

public class BasketNotFoundException(string Message) :NotFoundException($"basket with id {Message} is not found")
{
    
}
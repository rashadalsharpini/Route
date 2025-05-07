namespace Domain.Execptions;

public abstract class NotFoundException(string Message) : Exception(Message)
{
    
}
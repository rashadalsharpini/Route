namespace Domain.Execptions;

public sealed class ProductNotFoundException(int id) :NotFoundException($"product with id {id} not found")
{
    
}
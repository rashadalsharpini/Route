namespace Domain.Execptions;

public class DeliveryMethodNotFound(int id): NotFoundException($"DeliveryMethodNotFound {id}");
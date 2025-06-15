namespace PaymentService.API.Contracts.Events;

public class PaymentCompleted
{
    public Guid OrderId { get; set; }
    public bool Success { get; set; }
}

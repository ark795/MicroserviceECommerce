namespace PaymentService.API.Contracts.Events;

public class OrderCreated
{
    public Guid OrderId { get; set; }
    public string UserId { get; set; } = default!;
    public decimal TotalAmount { get; set; }
}

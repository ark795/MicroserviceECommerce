namespace OrderService.API.Domain.Entities;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserId { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Address { get; set; } = default!;
    public decimal TotalPrice { get; set; }

    public List<OrderItem> Items { get; set; } = new();
}

namespace CheckoutService.API.Domain.Entities;

public class BasketCheckout
{
    public string UserId { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Address { get; set; } = default!;
}

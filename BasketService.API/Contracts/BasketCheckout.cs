namespace BasketService.API.Contracts;

public class BasketCheckout
{
    public string UserId { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Address { get; set; } = default!;
}

namespace CheckoutService.API.Contracts.Commands;

public class SubmitOrder
{
    public string UserId { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Address { get; set; } = default!;
}

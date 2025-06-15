using MediatR;

namespace OrderService.API.Application.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public string UserId { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Address { get; set; } = default!;
        public List<CreateOrderItem> Items { get; set; } = new();
    }
}

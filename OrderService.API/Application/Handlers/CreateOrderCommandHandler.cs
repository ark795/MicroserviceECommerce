using MassTransit;
using MediatR;
using OrderService.API.Application.Commands;
using OrderService.API.Contracts.Events;
using OrderService.API.Domain.Entities;
using OrderService.API.Infrastructure.Persistence;

namespace OrderService.API.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly OrderDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateOrderCommandHandler(OrderDbContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order   /*.Domain.Entities.Order*/
            {
                UserId = request.UserId,
                Email = request.Email,
                Address = request.Address,
                TotalPrice = request.Items.Sum(i => i.Price * i.Quantity),
                Items = request.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);

            await _publishEndpoint.Publish(new OrderCreated
            {
                OrderId = order.Id,
                UserId = order.UserId,
                TotalPrice = order.TotalPrice
            }, cancellationToken);

            return order.Id;
        }
    }
}

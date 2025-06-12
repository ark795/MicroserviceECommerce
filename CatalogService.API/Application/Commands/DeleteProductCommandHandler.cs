using CatalogService.API.Contracts;
using CatalogService.API.Infrastructure.Persistence;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.API.Application.Commands;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly CatalogDbContext _context;
    private readonly IPublishEndpoint _publishEndpoint;

    public DeleteProductCommandHandler(CatalogDbContext context, IPublishEndpoint publishEndpoint)
    {
        _context = context;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);
        if (product == null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        await _publishEndpoint.Publish(new ProductCreated
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
        });
        return true;
    }
}

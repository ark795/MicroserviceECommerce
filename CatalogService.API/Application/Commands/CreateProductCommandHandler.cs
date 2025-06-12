using CatalogService.API.Contracts;
using CatalogService.API.Domain.Entities;
using CatalogService.API.Infrastructure.Persistence;
using MassTransit;
using MediatR;

namespace CatalogService.API.Application.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly CatalogDbContext _context;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateProductCommandHandler(CatalogDbContext context, IPublishEndpoint publishEndpoint)
    {
        _context = context;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        //publish event
        await _publishEndpoint.Publish(new ProductCreated
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        });

        return product;
    }
}

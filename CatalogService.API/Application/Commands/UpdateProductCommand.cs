using CatalogService.API.Domain.Entities;
using MediatR;

namespace CatalogService.API.Application.Commands;

public class UpdateProductCommand : IRequest<Product?>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

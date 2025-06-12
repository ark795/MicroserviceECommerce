using CatalogService.API.Domain.Entities;
using MediatR;

namespace CatalogService.API.Application.Commands;

public class CreateProductCommand : IRequest<Product>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
//public record CreateProductCommand(string Name, string Description, decimal Price) : IRequest;


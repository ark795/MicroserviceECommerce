using MediatR;

namespace CatalogService.API.Application.Commands;

public class DeleteProductCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

using CatalogService.API.Domain.Entities;
using MediatR;

namespace CatalogService.API.Application.Queries
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {
    }
}

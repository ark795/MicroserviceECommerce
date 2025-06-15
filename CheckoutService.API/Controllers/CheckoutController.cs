using BasketService.API.Domain.Entities;
using CheckoutService.API.Domain.Entities;
using CheckoutService.API.Infrastructure.Data;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.API.Application.Commands;
using System.Text.Json;

namespace CheckoutService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly RedisContext _redis;
        private readonly IRequestClient<CreateOrderCommand> _client;

        public CheckoutController(RedisContext redis, IRequestClient<CreateOrderCommand> client)
        {
            _redis = redis;
            _client = client;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckout model)
        {
            var basketJson = await _redis.Database.StringGetAsync(model.UserId);
            if (string.IsNullOrEmpty(basketJson)) return NotFound("Basket not found.");

            var basket = JsonSerializer.Deserialize<Basket>(basketJson!)!;
            var command = new CreateOrderCommand
            {
                UserId = model.UserId,
                Email = model.Email,
                Address = model.Address,
                Items = basket.Items.Select(i => new CreateOrderItem
                {
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            };

            var response = await _client.GetResponse<Response<Guid>>(command);
            return Ok(response.Message.Message);

            //var response = await _client.GetResponse<Guid>(command);
            //return Ok(response.Message);
        }
    }
}

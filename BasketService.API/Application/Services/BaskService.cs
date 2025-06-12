using BasketService.API.Application.Interfaces;
using BasketService.API.Domain.Entities;
using BasketService.API.Infrastructure.Data;
using Microsoft.AspNetCore.Components.Forms;
using System.Text.Json;

namespace BasketService.API.Application.Services;

public class BaskService : IBasketService
{
    private readonly RedisContext _redis;

    public BaskService(RedisContext redis) => _redis = redis;

    public async Task<Basket> GetBasketAsync(string userId)
    {
        var data = await _redis.Database.StringGetAsync(userId);
        if (data.IsNullOrEmpty) return new Basket { UserId = userId };

        return JsonSerializer.Deserialize<Basket>(data!)!;
    }

    public async Task<Basket> UpdateBasketAsync(Basket basket)
    {
        var serialized = JsonSerializer.Serialize(basket);
        await _redis.Database.StringSetAsync(basket.UserId, serialized);
        return basket;
    }

    public async Task DeleteBasketAsync(string userId)
    {
        await _redis.Database.KeyDeleteAsync(userId);
    }
}

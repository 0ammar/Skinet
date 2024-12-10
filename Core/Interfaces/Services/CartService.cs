using System.Text.Json;
using Core.Entities;
using StackExchange.Redis;

namespace Core.Interfaces.Services
{
    public class CartService(IConnectionMultiplexer redis) : ICartService
    {
        private readonly IDatabase _dataBase = redis.GetDatabase();
        public async Task<bool?> DeleteCartAsync(string key)
        {
            return await _dataBase.KeyDeleteAsync(key);
        }

        public async Task<ShoppingCart?> GetCartAsync(string key)
        {
            var data = await _dataBase.StringGetAsync(key);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<ShoppingCart>(data!);
        }

        public async Task<ShoppingCart?> SetCartAsync(ShoppingCart cart)
        {
            var created = await _dataBase.StringSetAsync(cart.Id,
            JsonSerializer.Serialize(cart), TimeSpan.FromDays(30));

            if(!created) return null;

            return await GetCartAsync(cart.Id);
        }
    }
}
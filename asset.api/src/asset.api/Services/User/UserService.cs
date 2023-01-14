using System.Text;
using asset.api.Models.Base;
using asset.api.Utilities.Constants;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace asset.api.Services.User;

public class UserService : IUserService
{
    private readonly HttpClient _client;
    private readonly IDistributedCache _distributedCache;
    private readonly IConfiguration _configuration;

    public UserService(
        IHttpClientFactory clientFactory,
        IDistributedCache distributedCache,
        IConfiguration configuration
    )
    {
        _client = clientFactory.CreateClient("UserApi");
        _distributedCache = distributedCache;
        _configuration = configuration;
    }

    public async Task<List<Entities.User>> GetUsersAsync()
    {
        string cacheKey = CacheConstants.GetAllUsers;

        var users = new List<Entities.User>();
        var serializedUsers = "";

        var encodedUsers = await _distributedCache.GetAsync(cacheKey);

        if (encodedUsers is null)
        {
            var response = await GetUsersCallAsync();
            users = response.Data;

            serializedUsers = JsonConvert.SerializeObject(users);
            encodedUsers = Encoding.UTF8.GetBytes(serializedUsers);

            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(double.Parse(_configuration["CacheOptions:SlidingExpirationMinutes"])))
                .SetAbsoluteExpiration(DateTime.Now.AddHours(double.Parse(_configuration["CacheOptions:AbsoluteExpirationHours"])));

            await _distributedCache.SetAsync(cacheKey, encodedUsers, options);
        }
        else
        {
            serializedUsers = Encoding.UTF8.GetString(encodedUsers);
            users = JsonConvert.DeserializeObject<List<Entities.User>>(serializedUsers);
        }

        return users;
    }


    private async Task<BaseResponse<List<Entities.User>>> GetUsersCallAsync()
    {
        var baseResponse = new BaseResponse<List<Entities.User>>();
        var response = await _client.GetAsync($"/api/users");

        if (!response.IsSuccessStatusCode)
        {
            var errors = JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());
            return baseResponse.SetError(errors);
        }

        var result = JsonConvert.DeserializeObject<BaseResponse<List<Entities.User>>>(
            await response.Content.ReadAsStringAsync()
        );
        return baseResponse.SetData(result.Data);
    }
}